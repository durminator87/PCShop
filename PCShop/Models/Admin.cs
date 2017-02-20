using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCShop.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage="Please enter the password", AllowEmptyStrings=true)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
    }
}