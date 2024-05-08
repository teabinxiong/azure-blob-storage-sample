using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorageSample.Uploader
{
	public sealed class AzureUploaderClient
	{
        private readonly BlobServiceClient _blobServiceClient;

		public AzureUploaderClient(string connectionString)
        {
			_blobServiceClient = new BlobServiceClient(
				connectionString
				);
		}

		public async Task<string> UploadFileAsync(string fileName,string localFilePath)
		{
			BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient("sadobimagecotainer001");

			
			// Get a reference to a blob
			BlobClient blobClient = containerClient.GetBlobClient(fileName);

			Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

			// Upload data from the local file, overwrite the blob if it already exists
			await blobClient.UploadAsync(localFilePath, true);

			return blobClient.Uri.ToString();
		}

		public async Task UploadBase64ToBlobStorageAsync(string base64String, string containerName, string fileName)
		{
			// Convert base64 string to byte array
			byte[] bytes = Convert.FromBase64String(base64String);

			// Get a container client object
			BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

			// Get a blob client object
			BlobClient blobClient = containerClient.GetBlobClient(fileName);

			Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

			// Upload data from the byte array, overwrite the blob if it already exists
			await blobClient.UploadAsync(new MemoryStream(bytes), true);
		}

	}
}
