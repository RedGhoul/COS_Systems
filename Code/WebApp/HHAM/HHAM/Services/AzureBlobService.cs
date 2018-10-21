using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using MultipartDataMediaFormatter.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HHAM.Services
{
    public class AzureBlobService
    {

        private CloudStorageAccount cloudStorageAccount;
        private CloudBlobClient cloudBlobClient;
        private readonly string UserProfileImages = "userprofileimages2";
        private readonly string PSScansRAWSeg = "psscansrawseg";
        private readonly string PSScansRAW = "psscansraw";

        public AzureBlobService()
        {
            cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureStorageConnectionString-2"));
            cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

        }

        public ICollection<string> GetAllPatientRawSeg(string patientNumber)
        {
            try
            {
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(PSScansRAWSeg);
                var listOfScanBlobs = cloudBlobContainer.ListBlobs().Where(x => x.Uri.ToString().Contains(patientNumber)).ToList();
                List<String> RAWSegURLs = new List<string>();

                foreach (var item in listOfScanBlobs)
                {
                    RAWSegURLs.Add(item.Uri.ToString());
                }

                return RAWSegURLs;
            }
            catch (Exception)
            {

                return null;
            }
        }
         
        public ICollection<string> GetAllPatientRawFiles(string patientNumber)
        {
            try
            {
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(PSScansRAW);

                var listOfScanBlobs = cloudBlobContainer.ListBlobs().Where(x => x.Uri.ToString().Contains(patientNumber)).ToList();
                List<String> RAWURLs = new List<string>();

                foreach (var item in listOfScanBlobs)
                {
                    RAWURLs.Add(item.Uri.ToString());
                }

                return RAWURLs;
            }
            catch (Exception)
            {

                return null;
            }
           
        }

        public string UploadProfileImageAsync(FormData.ValueFile ImageToUpload, string userID)
        {
            string ProfilePicturePath = null;
            if (ImageToUpload == null)
            {
                return null;
            }

            try
            {
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(UserProfileImages);
                string profilePictureName = Guid.NewGuid().ToString() + "-ProfileImage-" + userID;
                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(profilePictureName);
                //setting data type
                cloudBlockBlob.Properties.ContentType = ImageToUpload.GetType().Name;
                //uploading the byte array
                cloudBlockBlob.UploadFromByteArrayAsync(ImageToUpload.Value.Buffer, 0, ImageToUpload.Value.Buffer.Length);

                ProfilePicturePath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception)
            {
                return null;
            }
            return ProfilePicturePath;
        }

        public async Task<string> UploadRAWFileAsync(HttpPostedFileBase rawFile, string patientNumber)
        {
            string PatientRawFilePath = null;
            if (rawFile == null)
            {
                return null;
            }
            try
            {
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(PSScansRAW);
                
                string PatientRawFileName = Guid.NewGuid().ToString() + "-" + patientNumber +  "-RAWSCAN";

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(PatientRawFileName);

                cloudBlockBlob.Properties.ContentType = rawFile.GetType().Name;

                await cloudBlockBlob.UploadFromStreamAsync(rawFile.InputStream);

                PatientRawFilePath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception)
            {
                return null;
            }
            return PatientRawFilePath;
        }

        public bool IsValidRawFileURL(string rawFileURL)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(UserProfileImages);

            try
            {
                return cloudBlobContainer.GetBlockBlobReference(rawFileURL).Exists();
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async void DeleteRawFile(string rawFileURL)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(PSScansRAW);

            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(rawFileURL);
            await cloudBlockBlob.DeleteIfExistsAsync();
        }

        public async void DeleteRawSegFile(string rawSegFileURL)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(PSScansRAWSeg);

            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(rawSegFileURL);
            await cloudBlockBlob.DeleteIfExistsAsync();
        }
    }
}