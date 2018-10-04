using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HHAM.Models;
using AutoMapper;
using HHAM.DataTransferObjects;
using Microsoft.AspNet.Identity;

namespace HHAM.Controllers.APIControllers
{
    public class PatientsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("api/Patient/All/")]
        public async Task<IHttpActionResult> GetPatient()
        {
            List<Patient> listofPatients = await db.Patient.ToListAsync();
            List<PatientDto> patientDtos = new List<PatientDto>();
            Mapper.Map<List<Patient>, List<PatientDto>>(listofPatients, patientDtos);
            return Ok(patientDtos);
        }

        [Route("api/Patient/All/CurrentUser")]
        public HttpResponseMessage GetPatientForCurrentUser()
        {
            string userId = User.Identity.GetUserId();
            UserProfileInfo currentUser = db.UserProfileInfo.Include(x => x.Patients).Where(x => x.User.Id == userId).FirstOrDefault();
            List<Patient> listofPatients = currentUser.Patients.ToList();
            if (currentUser == null)
            {
                string errorMsg = "We can not complete that action right now";
                HttpError err = new HttpError(errorMsg);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }


            List<PatientDto> patientDtos = new List<PatientDto>();
            Mapper.Map<List<Patient>, List<PatientDto>>(listofPatients, patientDtos);
            return Request.CreateResponse(HttpStatusCode.OK, patientDtos);
        }

        [Route("api/Patient/Delete/{id}")]
        public async Task<HttpResponseMessage> DeletePatient(int id)
        {
            Patient patient = await db.Patient.FindAsync(id);
            if (patient == null)
            {
                string errorMsg = "We can not complete that action right now";
                HttpError err = new HttpError(errorMsg);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }

            db.Patient.Remove(patient);
            await db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, patient);
        }

        // GET: api/Patients/5
        [ResponseType(typeof(Patient))]
        public async Task<IHttpActionResult> GetPatient(int id)
        {
            Patient patient = await db.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // PUT: api/Patients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPatient(int id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.Id)
            {
                return BadRequest();
            }

            db.Entry(patient).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Patients
        [ResponseType(typeof(Patient))]
        public async Task<IHttpActionResult> PostPatient(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patient.Add(patient);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = patient.Id }, patient);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientExists(int id)
        {
            return db.Patient.Count(e => e.Id == id) > 0;
        }
    }
}