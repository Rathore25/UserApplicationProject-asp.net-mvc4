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

        public string PhoneNumber { get; set; }

        public string EmailId { get; set; }
    }
}