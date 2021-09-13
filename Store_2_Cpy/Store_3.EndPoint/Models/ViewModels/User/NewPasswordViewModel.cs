using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Models.ViewModels.User
{
    public class NewPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Password")]
        public string Token { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
