using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baltoppen.Models
{
    public partial class Login
    {
        [Required(ErrorMessage = "User Name is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

    }

    public partial class User
    {
        public int UserId { get; set; }

        
    }

}