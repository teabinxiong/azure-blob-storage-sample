using AzureBlobStorageSample.Uploader;

namespace AzureBlobStorageSample.Downloader
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Azure Blob Storage Sample downloader");

			var azureUploaderClient = new AzureDownloaderClient(
				"<Blob_Acct_Access_key>"
				);

			string fileBase64 = await azureUploaderClient.DownloadFileAsync("sadobimagecotainer001", "samplebase64_001.png");
		}
	}
}
