using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorageSample.Uploader
{
	public sealed class AzureDownloaderClient
	{
        private readonly BlobServiceClient _blobServiceClient;

		public AzureDownloaderClient(string connectionString)
        {
			_blobServiceClient = new BlobServiceClient(
				connectionString
				);
		}

		public async Task<string> DownloadFileAsync(string containerName,string blobName )
		{
			
			// Get a reference to a container
			BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

			// Get a reference to a blob
			BlobClient blobClient = containerClient.GetBlobClient(blobName);

			string base64String = String.Empty;
			// Download the blob's contents as a stream
			using (MemoryStream memoryStream = new MemoryStream())
			{
				await blobClient.DownloadToAsync(memoryStream);

				// Convert the stream to a Base64 string
				 base64String = Convert.ToBase64String(memoryStream.ToArray());

				Console.WriteLine($"Blob {blobName} has been downloaded as a Base64 string:");
				Console.WriteLine(base64String);
			}

			return base64String;
		}

    }
}
