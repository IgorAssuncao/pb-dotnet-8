using Repositories;
using System;
using System.IO;

namespace Services
{
    public class ImageService : IImageService
    {
        private IImageRepository ImageRepository { get; set; }

        public ImageService(IImageRepository imageRepository)
        {
            ImageRepository = imageRepository;
        }

        public string UploadFile(string type, Guid Id, string fileExtension, byte[] image)
        {
            Stream imageStream = new MemoryStream(image);
            string photoUrl = ImageRepository.UploadFile(type, Id, fileExtension, imageStream);
            return photoUrl;
        }
    }
}
