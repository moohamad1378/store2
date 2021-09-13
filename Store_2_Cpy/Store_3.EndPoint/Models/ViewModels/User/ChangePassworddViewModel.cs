using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Models.ViewModels.User
{
    public class ChangePassworddViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter EMail")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Token { get; set; }
        public string ReturnUrl { get; set; }
    }
}
