using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HHAM.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string patientNumber { get; set; }
        public DateTime BirthDate { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }
        [Display(Name = "Weight in Pounds (lb)")]
        public double Weight { get; set; }

        [Display(Name = "Height in Centimeters (cm)")]
        public double Height { get; set; }

        [Display(Name = "Date Admited")]
        public DateTime? DateAdmited { get; set; }

        [Display(Name = "Date Released")]
        public DateTime? DateReleased { get; set; }

        [Display(Name = "Personal Photo")]
        public string PersonalPhotoURL { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Care Givers")]
        public ICollection<UserProfileInfo> CareGivers { get; set; }

        public bool Married { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public BloodType BloodType { get; set; }
    }
}