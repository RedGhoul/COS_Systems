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

namespace HHAM.Controllers
{
    public class UserProfileInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserProfileInfoes
        public async Task<ActionResult> Index()
        {
            return View(await db.UserProfileInfo.ToListAsync());
        }

        // GET: UserProfileInfoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfileInfo userProfileInfo = await db.UserProfileInfo.FindAsync(id);
            if (userProfileInfo == null)
            {
                return HttpNotFound();
            }
            return View(userProfileInfo);
        }

        // GET: UserProfileInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfileInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description,UrlProfilePicture")] UserProfileInfo userProfileInfo)
        {
            if (ModelState.IsValid)
            {
                db.UserProfileInfo.Add(userProfileInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userProfileInfo);
        }

        // GET: UserProfileInfoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfileInfo userProfileInfo = await db.UserProfileInfo.FindAsync(id);
            if (userProfileInfo == null)
            {
                return HttpNotFound();
            }
            return View(userProfileInfo);
        }

        // POST: UserProfileInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description,UrlProfilePicture")] UserProfileInfo userProfileInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProfileInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userProfileInfo);
        }

        // GET: UserProfileInfoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfileInfo userProfileInfo = await db.UserProfileInfo.FindAsync(id);
            if (userProfileInfo == null)
            {
                return HttpNotFound();
            }
            return View(userProfileInfo);
        }

        // POST: UserProfileInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserProfileInfo userProfileInfo = await db.UserProfileInfo.FindAsync(id);
            db.UserProfileInfo.Remove(userProfileInfo);
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
