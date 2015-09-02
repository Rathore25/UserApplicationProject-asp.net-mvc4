using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UserApplication.Models
{
    public class UserModel
    {
        public string AutoId { get; set; }
        public string Uid { get; set; }

        public string Name { get; set; }

        public DateTime Dob { get; set; }


        public string City { get; set; }

        [StringLength(10, ErrorMessage = "Enter the 10 digit phone number", MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email Format is wrong")]
        public string EmailId { get; set; }
    }
}