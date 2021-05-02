using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DailyMenu.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
