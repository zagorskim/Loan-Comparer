using Azure.Storage.Blobs;
using BankAPI.Models;
using System.Text;

namespace BankAPI.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly BlobServiceClient _blobServiceClient;
        public FileManager()
        {
        }
        public FileManager(BlobServiceClient blobServiceClient) //injection
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task Upload(FileModel model)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("upload-file"); //container name

            var blobClient = blobContainer.GetBlobClient(model.ImageFile.FileName);

            await blobClient.UploadAsync(model.ImageFile.OpenReadStream());
        }

        public async Task<byte[]> Get(string imageName)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("upload-file");

            var blobClient = blobContainer.GetBlobClient(imageName);
            var downloadContent = await blobClient.DownloadAsync();
            using (MemoryStream ms = new MemoryStream())
            {
                await downloadContent.Value.Content.CopyToAsync(ms);
                return ms.ToArray();
            }
        }

        public string GetUrl(string imageName)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("upload-file");
            var blobClient = blobContainer.GetBlobClient(imageName);
            return blobClient.Uri.AbsoluteUri;
        }

        public void UploadTextFile(Inquiry inquiry)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("upload-file");
            var blob = blobContainer.GetBlobClient(inquiry.Id + "defaultfile.txt");
            var myStr = "Hello " + inquiry.FirstName + " " + inquiry.LastName;
            var content = Encoding.UTF8.GetBytes(myStr);
            using (var ms = new MemoryStream(content))
            {
                blob.Upload(ms);
            }
        }
    }
}
