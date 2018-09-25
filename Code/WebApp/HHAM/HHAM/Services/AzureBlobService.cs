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
        private CloudBlobContainer cloudBlobContainer;

        public AzureBlobService()
        {
            cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureStorageConnectionString-2"));
            cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            cloudBlobContainer = cloudBlobClient.GetContainerReference("pscans");
        }

        public async Task<string> UploadScanImageAsync(FormData.ValueFile ScanToUpload)
        {
            string PatientScanPath = null;
            if (ScanToUpload == null)
            {
                return null;
            }
            try
            {

                if (cloudBlobContainer.CreateIfNotExists())
                {
                    await cloudBlobContainer.SetPermissionsAsync(
                            new BlobContainerPermissions
                            {

                                PublicAccess = BlobContainerPublicAccessType.Blob
                            }
                        );
                }
                string imageName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(ScanToUpload.Name);

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
                cloudBlockBlob.Properties.ContentType = ScanToUpload.GetType().Name;
                await cloudBlockBlob.UploadFromByteArrayAsync(ScanToUpload.Value.Buffer, 0, ScanToUpload.Value.Buffer.Length);

                PatientScanPath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception)
            {
                return null;
            }
            return PatientScanPath;
        }

        public bool IsValid(string scanURL)
        {
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

        public async void DeletePic(string scanURL)
        {
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(scanURL);
            await cloudBlockBlob.DeleteIfExistsAsync();
        }
    }
}