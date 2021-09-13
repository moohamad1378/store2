using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store_2.Application.basketsService;
using Store_2.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Store_2.Application.Catalogs.CatalogItems.CatalogItemService;
using Store_2.Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Store_2.Application.Catalogs.CatalogItems.GetGatalogItemPDP;
using Store_2.Application.Catalogs.CatalogTypes;
using Store_2.Application.Catalogs.GetMenuItem;
using Store_2.Application.Comment.Commands;
using Store_2.Application.Discounts;
using Store_2.Application.HomePageService;
using Store_2.Application.Interface.Context;
using Store_2.Application.Orders;
using Store_2.Application.Orders.CustomerOrderService;
using Store_2.Application.Payments;
using Store_2.Application.Userss;
using Store_2.Application.Visitors.SaveVisitorInfo;
using Store_2.ApplicationUriComposer;
using Store_2.Infrastructure.IdentityConfigs;
using Store_2.Infrastructure.MappingProfile;
using Store_2.Persistance.Contexts;
using Store_2.Persistance.Contexts.MongoContexts;
using Store_3.EndPoint.MidleWares;
using Store_3.EndPoint.Utilities.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint
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
            services.AddControllersWithViews();
            services.AddDbContext<DataBaseContext>(options =>
            options.UseSqlServer(Configuration["ConnectionString:SqlServer1"]));

            services.AddTransient<IDataBaseContext, DataBaseContext>();

            services.AddTransient<IIdentityDatabaseContext, IdentityDataBaseContext>();
            services.AddIdentityService(Configuration);
            services.AddAuthorization();
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(999);
                options.LoginPath = "/Account/login";
                options.AccessDeniedPath = "/Account/Accessdenied";
                options.SlidingExpiration = true;
            });
            services.AddTransient(typeof(IMongoDBContext<>), typeof(MongoDBContext<>));
            //services.AddTransient<ISaveVisitorInfoService, SaveVisitorInfoService>();
            //services.AddScoped<SaveVisitorFilter>();
            services.AddTransient<IGetMenuItemService, GetMenuItemService>();
            services.AddTransient<IAddNewCatalogItemService, AddNewCatalogItemService>();
            services.AddTransient<IGetCatalogItemPLPService, GetCatalogItemPLPService>();
            services.AddTransient<IUriComposerServicer, UriComposerServicer>();
            services.AddTransient<IGetCatalogItemPDPService, GetCatalogItemPDPService>();
            services.AddTransient<IBasketservice, Basketservice>();
            services.AddTransient<IUserAddressService, UserAddressService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<IDiscountHistoryService, DiscountHistoryService>();
            services.AddTransient<ICatalogItemService, CatalogItemService>();
            services.AddTransient<ICustomerOrderService, CustomerOrderService>();
            services.AddTransient<IHomePageService, HomePageService>();
            services.AddMediatR(typeof(SendCommentCommand).Assembly);
            //mapper
            services.AddAutoMapper(typeof(CatalogMappingProfile));
            services.AddAutoMapper(typeof(UserMappingProfile));
            //gooogle service
            services.AddAuthentication()
                .AddGoogle(option=>
                {
                    option.ClientId = "192754428954-a5dr4sriddlodgk0e8g8bos86jcchepe.apps.googleusercontent.com";
                    option.ClientSecret = "NksJkgjpeiAuE-RywaB3eksB";
                });
            //
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
