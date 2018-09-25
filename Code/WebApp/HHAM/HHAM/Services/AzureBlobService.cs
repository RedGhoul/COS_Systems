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

        public AzureBlobService()
        {
            cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureStorageConnectionString-2"));
            cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
        }

        public ICollection<string> getAllPatientScans(int patientID)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + "scans");
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
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + "dicomfiles");
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
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + "scans");
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
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + "dicomfiles");
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

        public bool IsValid(string scanURL, string patientID)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + "scans");

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

        public async void DeletePic(string scanURL, string patientID)
        {
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(patientID.ToString() + "scans");

            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(scanURL);
            await cloudBlockBlob.DeleteIfExistsAsync();
        }
    }
}