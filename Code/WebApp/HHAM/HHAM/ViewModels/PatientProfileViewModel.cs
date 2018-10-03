using HHAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHAM.ViewModels
{
    public class PatientProfileViewModel
    {
        public int Id { get; set; }

        
        // Side Bar Section
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatientNumber { get; set; }

        // Stats Section
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public bool Married { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public DateTime? DateAdmited { get; set; }
        public DateTime? DateReleased { get; set; }
        public BloodType BloodType { get; set; }
        public string Notes { get; set; }
        public ICollection<Scan> ScanURLs { get; set; }
        public ICollection<UserProfileInfo> CareGivers { get; set; }
    }
}