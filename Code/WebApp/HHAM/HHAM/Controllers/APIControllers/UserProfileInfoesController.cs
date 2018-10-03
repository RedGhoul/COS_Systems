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

namespace HHAM.Controllers.APIControllers
{
    public class UserProfileInfoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UserProfileInfoes
        public IQueryable<UserProfileInfo> GetUserProfileInfo()
        {
            return db.UserProfileInfo;
        }

        // GET: api/UserProfileInfoes/5
        [ResponseType(typeof(UserProfileInfo))]
        public async Task<IHttpActionResult> GetUserProfileInfo(int id)
        {
            UserProfileInfo userProfileInfo = await db.UserProfileInfo.FindAsync(id);
            if (userProfileInfo == null)
            {
                return NotFound();
            }

            return Ok(userProfileInfo);
        }

        // PUT: api/UserProfileInfoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserProfileInfo(int id, UserProfileInfo userProfileInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProfileInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(userProfileInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileInfoExists(id))
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

        // POST: api/UserProfileInfoes
        [ResponseType(typeof(UserProfileInfo))]
        public async Task<IHttpActionResult> PostUserProfileInfo(UserProfileInfo userProfileInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserProfileInfo.Add(userProfileInfo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userProfileInfo.Id }, userProfileInfo);
        }

        // DELETE: api/UserProfileInfoes/5
        [ResponseType(typeof(UserProfileInfo))]
        public async Task<IHttpActionResult> DeleteUserProfileInfo(int id)
        {
            UserProfileInfo userProfileInfo = await db.UserProfileInfo.FindAsync(id);
            if (userProfileInfo == null)
            {
                return NotFound();
            }

            db.UserProfileInfo.Remove(userProfileInfo);
            await db.SaveChangesAsync();

            return Ok(userProfileInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserProfileInfoExists(int id)
        {
            return db.UserProfileInfo.Count(e => e.Id == id) > 0;
        }
    }
}