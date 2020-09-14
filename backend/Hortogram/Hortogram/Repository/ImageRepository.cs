using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Settings;
using System;
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

        public void UploadFile(Guid userId, Stream imageStream)
        {
            BlobClient = ContainerClient.GetBlobClient($"{userId}-{DateTime.UtcNow}");
            BlobClient.Upload(imageStream);
        }
    }
}
