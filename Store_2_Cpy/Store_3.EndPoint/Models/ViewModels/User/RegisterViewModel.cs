using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Models.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Name and Last Name")]
        [MaxLength(70)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "enter repeat Password")]
        [Compare(nameof(Password), ErrorMessage = "repeated Password not Equal Password")]
        [Display(Name = "repeat Password")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}
