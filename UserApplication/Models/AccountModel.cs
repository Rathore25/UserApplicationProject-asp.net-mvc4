using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UserApplication.Models
{
    public class RegisterModel
    {
        public string AutoId { get; set; }

        public string Guid { get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        [StringLength(10, ErrorMessage = "The username must be 5 to 10 characters long.", MinimumLength = 5)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [StringLength(20, ErrorMessage = "The password must be {2} to 20 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please retype the above password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your full name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your email id")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email Format is wrong")]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }
    }


    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter a username")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}