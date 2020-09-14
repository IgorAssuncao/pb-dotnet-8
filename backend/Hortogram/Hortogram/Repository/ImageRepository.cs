using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Settings;
using System;
using System.Globalization;
using System.IO;

namespace Repositories
{
    public class ImageRepository : IImageRepository
    {
        private CommonSettings Settings { get; set; }
        private string StorageConnectionString { get; set; }
        private string ContainerName = "images-pb8";
        private BlobContainerClient ContainerClient { get; set; }
        private BlobClient BlobClient { get; set; }

        public ImageRepository(IConfiguration config)
        {
            Settings = new CommonSettings(config);
            StorageConnectionString = Settings.GetStorageConnectionString();
            ContainerClient = new BlobContainerClient(StorageConnectionString, ContainerName);
            ContainerClient.CreateIfNotExists();
        }

        public string UploadFile(string type, Guid Id, string fileExtension, Stream imageStream)
        {
            string now = DateTime.UtcNow.ToString("u", CultureInfo.InvariantCulture);
            BlobClient = ContainerClient.GetBlobClient($"{type}-{Id}-{now}.{fileExtension}");
            BlobClient.Upload(imageStream);
            return BlobClient.Uri.ToString();
        }
    }
}
