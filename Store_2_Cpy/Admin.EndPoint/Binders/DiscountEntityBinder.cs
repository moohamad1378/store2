using MD.PersianDateTime.Standard;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store_2.Application.Discounts.AddNewDiscountservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.EndPoint.Binders
{
    public class DiscountEntityBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new AggregateException(nameof(bindingContext));
            }
            string FieldName = bindingContext.FieldName;
            AddNewDiscountDto discountDto = new AddNewDiscountDto()

            {
                CoponCode = bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.CoponCode)}").Values.ToString(),


                DiscountAmount = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.DiscountAmount)}").Values.ToString()),

                DiscountLimitationId = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.DiscountLimitationId)}").Values.ToString()),


                DiscountPercentage = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.DiscountPercentage)}").Values.ToString()),

                DiscountTypeId = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.DiscountTypeId)}").Values.ToString()),
                LimitationTimes = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.LimitationTimes)}").Values.ToString()),

                UsePercentage = bool.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.UsePercentage)}").FirstValue.ToString()),

                Name = bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.Name)}").Values.ToString(),

                RequiredCouponCode = bool.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.RequiredCouponCode)}").FirstValue.ToString()),

                EndDate = PersianDateTime.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.EndDate)}").Values.ToString()),

                StartDate = PersianDateTime.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.StartDate)}").Values.ToString()),
            };
            var appliedToCatalogItem = bindingContext.ValueProvider.GetValue("model.appliedToCatalogItem");

            if (!string.IsNullOrEmpty(appliedToCatalogItem.Values))
            {
                discountDto.appliedToCatalogItem =
                bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.appliedToCatalogItem)}")
                .Values.ToString().Split(',').Select(x => Int32.Parse(x)).ToList();
            }


            bindingContext.Result = ModelBindingResult.Success(discountDto);
            return Task.CompletedTask;
        }
    }
}
