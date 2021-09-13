using Admin.EndPoint.MappingProfiles;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store_2.Application.banners;
using Store_2.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Store_2.Application.Catalogs.CatalogItems.CatalogItemService;
using Store_2.Application.Catalogs.CatalogTypes;
using Store_2.Application.Discounts;
using Store_2.Application.Discounts.AddNewDiscountservice;
using Store_2.Application.Interface.Context;
using Store_2.Application.Visitors.GetTodayReport;
using Store_2.ApplicationUriComposer;
using Store_2.Infrastructure.Externalapi.ImagesServer;
using Store_2.Infrastructure.MappingProfile;
using Store_2.Persistance.Contexts;
using Store_2.Persistance.Contexts.MongoContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.EndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddControllers();
            services.AddDbContext<DataBaseContext>(options =>
            options.UseSqlServer(Configuration["ConnectionString:SqlServer1"]));
            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddTransient<IGetTodayReportService, GetTodayReportService>();
            services.AddTransient(typeof(IMongoDBContext<>), typeof(MongoDBContext<>));
            services.AddTransient<ICatalogItemService, CatalogItemService>();
            services.AddTransient<IAddNewCatalogItemService, AddNewCatalogItemService>();
            services.AddTransient<IimageUploadService, imageUploadService>();
            services.AddTransient<IAddNewDiscountservice, AddNewDiscountservice>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<IDiscountHistoryService, DiscountHistoryService>();
            services.AddTransient<IUriComposerServicer, UriComposerServicer>();
            services.AddTransient<IBannerService, BannerService>();
            //fluentvalidation
            services.AddTransient<IValidator<AddNewCatalogItemDto>, AddNewCatalogItemDtoValidator>();
            
            //mapper
            services.AddAutoMapper(typeof(CatalogMappingProfile));

            //
            services.AddTransient<ICatalogTypeService, CatalogTypeService>();
            services.AddAutoMapper(typeof(CatalogVMMappingProfile));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
