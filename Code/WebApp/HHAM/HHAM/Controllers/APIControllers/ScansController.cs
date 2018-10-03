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

namespace HHAM.Controllers.APIControllers
{
    public class ScansController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("api/Patient/{idPatient}/Scan/All")]
        public async Task<HttpResponseMessage> GetPatientScans(string idPatient)
        {
            List<Scan> Scans = await db.Photos.ToListAsync();
            if (Scans == null)
            {
                string errorMsg = "We can not find any entries";
                HttpError err = new HttpError(errorMsg);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            List<ScanDto> ScanDtos = new List<ScanDto>();
            Mapper.Map<List<Scan>, List<ScanDto>>(Scans, ScanDtos);
            return Request.CreateResponse(HttpStatusCode.OK,ScanDtos);
        }

        [Route("api/Patient/{idPatient}/Scan/Delete/{idScan}")]
        public async Task<HttpResponseMessage> DeletePhoto(int idPatient, int idScan)
        {
            Scan photo = await db.Photos.FindAsync(idScan);
            if (photo == null)
            {
                string errorMsg = "We can not complete that action right now";
                HttpError err = new HttpError(errorMsg);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }

            db.Photos.Remove(photo);
            await db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, photo);
        }


        // GET: api/Photos/5
        [ResponseType(typeof(Scan))]
        public async Task<IHttpActionResult> GetScan(int id)
        {
            Scan photo = await db.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            return Ok(photo);
        }

        // PUT: api/Photos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhoto(int id, Scan photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != photo.Id)
            {
                return BadRequest();
            }

            db.Entry(photo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
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

        // POST: api/Photos
        [ResponseType(typeof(Scan))]
        public async Task<IHttpActionResult> PostPhoto(Scan photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Photos.Add(photo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = photo.Id }, photo);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhotoExists(int id)
        {
            return db.Photos.Count(e => e.Id == id) > 0;
        }
    }
}