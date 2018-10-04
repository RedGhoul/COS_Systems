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
using AutoMapper;
using MultipartDataMediaFormatter.Infrastructure;
using HHAM.Services;

namespace HHAM.Controllers
{
    public class ScansController : Controller
    {
        private ApplicationDbContext _dbContext;
        private readonly AzureBlobService _blobService;

        public ScansController()
        {
            _dbContext = new ApplicationDbContext();
            _blobService = new AzureBlobService();
        }

        public ActionResult Index(string PatientNumber)
        {
            ScansAreaViewModel ViewModel = new ScansAreaViewModel {
                Patient = _dbContext.Patient.Where(x => x.PatientNumber == PatientNumber).FirstOrDefault()
            };
            return View(ViewModel);
        }

        public ActionResult Create(string PatientNumber)
        {
            if (PatientNumber == null)
            {
                return HttpNotFound();
            }

            CreateScanViewModel createScanViewModel = new CreateScanViewModel
            {
                PatientNumber = PatientNumber
            };

            return View(createScanViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateScanViewModel createScanViewModel)
        {
           
            return View();
        }


        // GET: Photos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scan scan = await _dbContext.Photos.FindAsync(id);
            if (scan == null)
            {
                return HttpNotFound();
            }
            return View(scan);
        }

       

        // GET: Photos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scan photo = await _dbContext.Photos.FindAsync(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DateAdded,DisplayURL,DisplayURLProcessedImage,Notes")] Scan photo)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(photo).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // GET: Photos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scan photo = await _dbContext.Photos.FindAsync(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Scan photo = await _dbContext.Photos.FindAsync(id);
            _dbContext.Photos.Remove(photo);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
