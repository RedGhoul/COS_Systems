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
using HHAM.DataTransferObjects;
using HHAM.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MultipartDataMediaFormatter.Infrastructure;

namespace HHAM.Controllers.APIControllers
{
    [Authorize]
    public class UserProfileInfoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // for the admin table
        [Route("api/UserProfile/All")]
        public async Task<HttpResponseMessage> GetUserProfiles()
        {
            List<UserProfileInfo> UserProfileInfos = await db.UserProfileInfo.ToListAsync();
            if (UserProfileInfos == null)
            {
                string errorMsg = "We can not find any entries";
                HttpError err = new HttpError(errorMsg);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            List<UserProfileInfoDto> UserProfileInfoDtos = new List<UserProfileInfoDto>();
            Mapper.Map<List<UserProfileInfo>, List<UserProfileInfoDto>>(UserProfileInfos, UserProfileInfoDtos);
            return Request.CreateResponse(HttpStatusCode.OK, UserProfileInfoDtos);
        }


        [Route("api/UserProfile/Change/FirstName")]
        public HttpResponseMessage ChangeFirstName(UserProfileInfoDto user)
        {
            string userId = User.Identity.GetUserId();
            UserProfileInfo currentUserProfile = db.UserProfileInfo.Where(x => x.User.Id == userId).FirstOrDefault();
            currentUserProfile.FirstName = user.FirstName;
            db.Entry(currentUserProfile).State = EntityState.Modified;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("api/UserProfile/Change/LastName")]
        public HttpResponseMessage ChangeLastName(UserProfileInfoDto user)
        {
            string userId = User.Identity.GetUserId();
            UserProfileInfo currentUserProfile = db.UserProfileInfo.Where(x => x.User.Id == userId).FirstOrDefault();
            currentUserProfile.LastName = user.LastName;
            db.Entry(currentUserProfile).State = EntityState.Modified;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("api/UserProfile/Change/Description")]
        public HttpResponseMessage ChangeDescription(UserProfileInfoDto user)
        {
            string userId = User.Identity.GetUserId();
            UserProfileInfo currentUserProfile = db.UserProfileInfo.Where(x => x.User.Id == userId).FirstOrDefault();
            currentUserProfile.Description = user.Description;
            db.Entry(currentUserProfile).State = EntityState.Modified;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("api/UserProfile/UploadUserImage")]
        public IHttpActionResult Upload(FormData formData)
        {
            return Ok(formData.Files[0]);
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