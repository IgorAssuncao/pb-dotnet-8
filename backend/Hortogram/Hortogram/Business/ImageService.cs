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

        public void UploadFile(Guid userId, Stream image)
        {
            ImageRepository.UploadFile(userId, image);
        }
    }
}
