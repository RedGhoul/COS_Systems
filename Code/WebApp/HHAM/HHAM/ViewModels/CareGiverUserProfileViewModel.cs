using HHAM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HHAM.ViewModels
{
    public class CareGiverUserProfileViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Profile Picture")]
        public string UrlProfilePicture { get; set; }
        [Display(Name = "Health Care Occupation")]
        public string Role { get; set; }
    }
}