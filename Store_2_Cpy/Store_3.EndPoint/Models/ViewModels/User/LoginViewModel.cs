using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Models.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool IsPersistent { get; set; } = false;

        public string ReturnUrl { get; set; }
        public string LoginWIthGoogle { get; set; }
    }
}
