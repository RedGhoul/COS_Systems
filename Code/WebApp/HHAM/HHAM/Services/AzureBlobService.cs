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
        public static AzureBlobService instance;

        private CloudStorageAccount cloudStorageAccount;
        private CloudBlobClient cloudBlobClient;
        private string DICOMContainerEnding = "dicomfiles";
        private string ScansContainerEnding = "scans";

        public AzureBlobService()
        {
            if(instance == null)
            {
                instance = new AzureBlobService();
                cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureStorageConnectionString-2"));
                cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            }
           
        }

        public ICollection<string> getAllPatientScans(int patientID)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + ScansContainerEnding);
            cloudBlobContainer.CreateIfNotExists();

            var listOfScanBlobs = cloudBlobContainer.ListBlobs().ToList();
            List<String> ScanURLs = new List<string>();
            foreach (var item in listOfScanBlobs)
            {
                ScanURLs.Add(item.Uri.ToString());
            }

            return ScanURLs;
        }
         
        public ICollection<string> getAllPatientDICOMFiles(int patientID)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + DICOMContainerEnding);
            cloudBlobContainer.CreateIfNotExists();

            var listOfScanBlobs = cloudBlobContainer.ListBlobs().ToList();
            List<String> ScanURLs = new List<string>();
            foreach (var item in listOfScanBlobs)
            {
                ScanURLs.Add(item.Uri.ToString());
            }

            return ScanURLs;
        }



        public async Task<string> UploadScanImageAsync(FormData.ValueFile ScanToUpload, int patientID)
        {
            string PatientScanPath = null;
            if (ScanToUpload == null)
            {
                return null;
            }
            try
            {
                //getting the patients container
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + ScansContainerEnding);
                if (cloudBlobContainer.CreateIfNotExists())
                {
                    await cloudBlobContainer.SetPermissionsAsync(
                            new BlobContainerPermissions
                            {

                                PublicAccess = BlobContainerPublicAccessType.Blob
                            }
                        );
                }
                //creating the scan name
                string scanName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(ScanToUpload.Name);
                //making the blob ref
                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(scanName);
                //setting data type
                cloudBlockBlob.Properties.ContentType = ScanToUpload.GetType().Name;
                //uploading the byte array
                await cloudBlockBlob.UploadFromByteArrayAsync(ScanToUpload.Value.Buffer, 0, ScanToUpload.Value.Buffer.Length);

                PatientScanPath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception)
            {
                return null;
            }
            return PatientScanPath;
        }

        public async Task<string> UploadProfileImageAsync(FormData.ValueFile ImageToUpload, string userID)
        {
            string ProfilePicturePath = null;
            if (ImageToUpload == null)
            {
                return null;
            }
            try
            {
                //getting the patients container
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(ProfilePicturePath.ToString() + ScansContainerEnding);
                if (cloudBlobContainer.CreateIfNotExists())
                {
                    await cloudBlobContainer.SetPermissionsAsync(
                            new BlobContainerPermissions
                            {

                                PublicAccess = BlobContainerPublicAccessType.Blob
                            }
                        );
                }
                //creating the scan name
                string pictureName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(ImageToUpload.Name) + "-ProfileImage";
                //making the blob ref
                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(pictureName);
                //setting data type
                cloudBlockBlob.Properties.ContentType = ImageToUpload.GetType().Name;
                //uploading the byte array
                await cloudBlockBlob.UploadFromByteArrayAsync(ImageToUpload.Value.Buffer, 0, ImageToUpload.Value.Buffer.Length);

                ProfilePicturePath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception)
            {
                return null;
            }
            return ProfilePicturePath;
        }

        public async Task<string> UploadDICOMFileAsync(FormData.ValueFile DICOMFileToUpload, int patientID)
        {
            string PatientDICOMPath = null;
            if (DICOMFileToUpload == null)
            {
                return null;
            }
            try
            {
                //getting the patients container
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + DICOMContainerEnding);
                if (cloudBlobContainer.CreateIfNotExists())
                {
                    await cloudBlobContainer.SetPermissionsAsync(
                            new BlobContainerPermissions
                            {

                                PublicAccess = BlobContainerPublicAccessType.Blob
                            }
                        );
                }
                //creating the scan name
                string scanName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(DICOMFileToUpload.Name);
                //making the blob ref
                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(scanName);
                //setting data type
                cloudBlockBlob.Properties.ContentType = DICOMFileToUpload.GetType().Name;
                //uploading the byte array
                await cloudBlockBlob.UploadFromByteArrayAsync(DICOMFileToUpload.Value.Buffer, 0, DICOMFileToUpload.Value.Buffer.Length);

                PatientDICOMPath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception)
            {
                return null;
            }
            return PatientDICOMPath;
        }

        public bool IsValidScanImageURL(string scanURL, string patientID)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + ScansContainerEnding);

            try
            {
                cloudBlobContainer.GetBlockBlobReference(scanURL);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool IsValidDICOMFileURL(string DICOMFileURL, string patientID)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + DICOMContainerEnding);

            try
            {
                cloudBlobContainer.GetBlockBlobReference(DICOMFileURL);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async void DeleteScan(string scanURL, string patientID)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + ScansContainerEnding);

            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(scanURL);
            await cloudBlockBlob.DeleteIfExistsAsync();
        }

        public async void DeleteDICOMFile(string DICOMFileURL, string patientID)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + DICOMContainerEnding);

            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(DICOMFileURL);
            await cloudBlockBlob.DeleteIfExistsAsync();
        }
    }
}