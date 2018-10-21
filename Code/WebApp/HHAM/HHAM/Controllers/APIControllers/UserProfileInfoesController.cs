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
using HHAM.Services;

namespace HHAM.Controllers.APIControllers
{
    [Authorize]
    public class UserProfileInfoesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        private AzureBlobService _blobService;
        public UserProfileInfoesController()
        {
            _dbContext = new ApplicationDbContext();
            _blobService = new AzureBlobService();
        }

        // for the admin table
        [Route("api/UserProfile/All")]
        public async Task<HttpResponseMessage> GetUserProfiles()
        {
            List<UserProfileInfo> UserProfileInfos = await _dbContext.UserProfileInfo.ToListAsync();
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
            UserProfileInfo currentUserProfile = _dbContext.UserProfileInfo.Where(x => x.User.Id == userId).FirstOrDefault();
            currentUserProfile.FirstName = user.FirstName;
            _dbContext.Entry(currentUserProfile).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("api/UserProfile/Change/LastName")]
        public HttpResponseMessage ChangeLastName(UserProfileInfoDto user)
        {
            string userId = User.Identity.GetUserId();
            UserProfileInfo currentUserProfile = _dbContext.UserProfileInfo.Where(x => x.User.Id == userId).FirstOrDefault();
            currentUserProfile.LastName = user.LastName;
            _dbContext.Entry(currentUserProfile).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("api/UserProfile/Change/Description")]
        public HttpResponseMessage ChangeDescription(UserProfileInfoDto user)
        {
            string userId = User.Identity.GetUserId();
            UserProfileInfo currentUserProfile = _dbContext.UserProfileInfo.Where(x => x.User.Id == userId).FirstOrDefault();
            currentUserProfile.Description = user.Description;
            _dbContext.Entry(currentUserProfile).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("api/UserProfile/UploadUserImage")]
        public HttpResponseMessage Upload(FormData formData)
        {
            string userId = User.Identity.GetUserId();
            string profilePictureUrl = _blobService.UploadProfileImageAsync(formData.Files[0], userId);
            UserProfileInfo currentUserProfile = _dbContext.UserProfileInfo.Where(x => x.User.Id == userId).FirstOrDefault();
            currentUserProfile.UrlProfilePicture = profilePictureUrl;
            _dbContext.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, profilePictureUrl);
        }

        [HttpGet]
        [Route("api/UserProfile/GetUserImage")]
        public HttpResponseMessage GetProfileImage()
        {
            string userId = User.Identity.GetUserId();
            UserProfileInfo currentUserProfile = _dbContext.UserProfileInfo.Where(x => x.User.Id == userId).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, currentUserProfile.UrlProfilePicture);
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

            _dbContext.Entry(userProfileInfo).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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

            _dbContext.UserProfileInfo.Add(userProfileInfo);
            await _dbContext.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userProfileInfo.Id }, userProfileInfo);
        }

        // DELETE: api/UserProfileInfoes/5
        [ResponseType(typeof(UserProfileInfo))]
        public async Task<IHttpActionResult> DeleteUserProfileInfo(int id)
        {
            UserProfileInfo userProfileInfo = await _dbContext.UserProfileInfo.FindAsync(id);
            if (userProfileInfo == null)
            {
                return NotFound();
            }

            _dbContext.UserProfileInfo.Remove(userProfileInfo);
            await _dbContext.SaveChangesAsync();

            return Ok(userProfileInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserProfileInfoExists(int id)
        {
            return _dbContext.UserProfileInfo.Count(e => e.Id == id) > 0;
        }
    }
}