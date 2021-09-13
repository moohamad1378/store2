using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.EndPoint.Binders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store_2.Application.Discounts.AddNewDiscountservice;

namespace Admin.EndPoint.Pages.Discounts
{   
    public class CreateModel : PageModel
    {
        private readonly IAddNewDiscountservice _addNewDiscountservice;
        [ModelBinder(BinderType =typeof( DiscountEntityBinder))]
        [BindProperty]
        public AddNewDiscountDto model { get; set; }
        public CreateModel(IAddNewDiscountservice addNewDiscountservice)
        {
            _addNewDiscountservice = addNewDiscountservice;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            _addNewDiscountservice.Execute(model);
        }
    }
}
