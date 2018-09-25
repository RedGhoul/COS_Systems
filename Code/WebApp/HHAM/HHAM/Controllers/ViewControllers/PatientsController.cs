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

namespace HHAM.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private AzureBlobService ScanStore = new AzureBlobService();

        // GET: Patients
        public ActionResult Index()
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
            Patient patient = db.Patient.Include(x => x.Gender).Include(x => x.CareGivers).Include(x => x.BloodType).Where(x => x.Id == id).FirstOrDefault();

            if (patient == null)
            {
                return HttpNotFound();
            }
            var viewModel = new PatientProfileViewModel
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                CurrentGender = patient.Gender,
                Weight = patient.Weight,
                Height = patient.Height,
                Married = patient.Married,
                PrimaryAddress = patient.PrimaryAddress,
                SecondaryAddress = patient.SecondaryAddress,
                DateAdmited = patient.DateAdmited,
                DateReleased = patient.DateReleased,
                CurrentBloodType = patient.BloodType,
                Notes = patient.Notes,
                ScanURLs = db.Photos.ToList(),
                CareGivers = patient.CareGivers
            };

            return View(viewModel);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Weight,Height,DateAdmited,DateReleased,PersonalPhotoURL,Notes")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patient.Add(patient);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patient.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Weight,Height,DateAdmited,DateReleased,PersonalPhotoURL,Notes")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patient.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Patient patient = await db.Patient.FindAsync(id);
            db.Patient.Remove(patient);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
