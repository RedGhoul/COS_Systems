using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HHAM.Models;
using HHAM.ViewModels;
using HHAM.Services;
using AutoMapper;
using Microsoft.AspNet.Identity;
using HHAM.DataTransferObjects;

namespace HHAM.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private AzureBlobService azureBlobService = new AzureBlobService();

        // GET: Patients
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CurrentPatients()
        {
            return View();
        }

        // GET: Patients/Details/5
        public ActionResult PatientProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Patient patient = db.Patient.Include(x => x.Gender)
                .Include(x => x.CareGivers)
                .Include(x => x.BloodType)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (patient == null)
            {
                return HttpNotFound();
            }

            PatientProfileViewModel viewModel = new PatientProfileViewModel();

            Mapper.Map<Patient, PatientProfileViewModel>(patient, viewModel);

            int calculatedAge = new DateTime(DateTime.Now.Subtract(patient.BirthDate).Ticks).Year - 1;

            DateTime? dateReleased = null;
            if (patient.DateReleased != null)
            {
                dateReleased = patient.DateReleased;
            }
            viewModel.Age = calculatedAge;
            viewModel.DateReleased = dateReleased;

            return View(viewModel);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            CreatePatientViewModel createPatientViewModel = new CreatePatientViewModel
            {
                _genders = db.Genders.ToList(),
                _bloodTypes = db.BloodTypes.ToList()
            };
            return View(createPatientViewModel);
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePatientViewModel patientViewModel)
        {
            try
            {
                Patient newPatient = new Patient();
                Mapper.Map<CreatePatientViewModel, Patient>(patientViewModel, newPatient);
                newPatient.Gender = db.Genders.Where(x => x.Id == patientViewModel.SelectedGenderId).FirstOrDefault();
                newPatient.BloodType = db.BloodTypes.Where(x => x.Id == patientViewModel.SelectedBloodTypeId).FirstOrDefault();
                db.Patient.Add(newPatient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                CreatePatientViewModel createPatientViewModel = new CreatePatientViewModel
                {
                    _genders = db.Genders.ToList(),
                    _bloodTypes = db.BloodTypes.ToList()
                };
                return View(createPatientViewModel);
            }
        }

        // GET: Patients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Patient patient = db.Patient.Include(x => x.Gender)
            .Include(x => x.CareGivers)
            .Include(x => x.BloodType)
            .Where(x => x.Id == id)
            .FirstOrDefault();

            if (patient == null)
            {
                return HttpNotFound();
            }

            int foundSelectedBloodTypeId = 0;

            if (patient.BloodType != null)
            {
                foundSelectedBloodTypeId = patient.BloodType.Id;
            }

            int foundSelectedGenderId = 0;
            if (patient.Gender != null)
            {
                foundSelectedGenderId = patient.Gender.Id;
            }

            EditPatientViewModel editPatientViewModel = new EditPatientViewModel
            {
                SelectedBloodTypeId = foundSelectedBloodTypeId,
                SelectedGenderId = foundSelectedGenderId,
                _genders = db.Genders.ToList(),
                _bloodTypes = db.BloodTypes.ToList(),
            };

            Mapper.Map<Patient, EditPatientViewModel>(patient, editPatientViewModel);
            
            return View(editPatientViewModel);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditPatientViewModel editPatientViewModel)
        {
            try
            {
                Patient modifiedPatient = db.Patient.Include(x => x.Gender)
                .Include(x => x.CareGivers)
                .Include(x => x.BloodType)
                .Where(x => x.Id == editPatientViewModel.Id)
                .FirstOrDefault();

                Mapper.Map<EditPatientViewModel, Patient>(editPatientViewModel, modifiedPatient);
                modifiedPatient.Gender = db.Genders.Where(x => x.Id == editPatientViewModel.SelectedGenderId).FirstOrDefault();
                modifiedPatient.BloodType = db.BloodTypes.Where(x => x.Id == editPatientViewModel.SelectedBloodTypeId).FirstOrDefault();
                db.Entry(modifiedPatient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                EditPatientViewModel createPatientViewModel = new EditPatientViewModel
                {
                    _genders = db.Genders.ToList(),
                    _bloodTypes = db.BloodTypes.ToList()
                };
                return View(createPatientViewModel);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
