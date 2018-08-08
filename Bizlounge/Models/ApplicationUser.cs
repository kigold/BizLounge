using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bizlounge.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //add extra fields
        public string FullName { get; set; }
        [Display(Name = "Bank Name")]
        public string Bank { get; set; }
        [Display(Name = "Account Name")]
        public string BankAccountName { get; set; }
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
        public string Location { get; set; }
        public System.DateTime? BirthDate { get; set; }

    }
}
