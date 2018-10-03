using HHAM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HHAM.ViewModels
{
    public class EditPatientViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public bool Married { get; set; }

        [Display(Name = "Primary Address")]
        public string PrimaryAddress { get; set; }
        [Display(Name = "Secondary Address")]
        public string SecondaryAddress { get; set; }
        [Display(Name = "Date Admited")]
        public DateTime DateAdmited { get; set; }
        public string Notes { get; set; }

        public ICollection<Gender> _genders { get; set; }

        [Display(Name = "Gender")]
        public int SelectedGenderId { get; set; }

        public IEnumerable<SelectListItem> GenderItems
        {
            get { return new SelectList(_genders, "Id", "Value"); }
        }

        public ICollection<BloodType> _bloodTypes { get; set; }

        [Display(Name = "Blood Type")]
        public int SelectedBloodTypeId { get; set; }

        public IEnumerable<SelectListItem> BloodTypeItems
        {
            get { return new SelectList(_bloodTypes, "Id", "Value"); }
        }
    }
}