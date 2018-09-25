using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHAM.Models
{
    public class UserProfileInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        public string Description { get; set; }
        public string UrlProfilePicture { get; set; }
        public string Role { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}