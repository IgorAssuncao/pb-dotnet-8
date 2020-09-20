using Repositories;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Services
{
    public class ImageService : IImageService
    {
        private IImageRepository ImageRepository { get; set; }

        public ImageService(IImageRepository imageRepository)
        {
            ImageRepository = imageRepository;
        }

        public async Task<string> UploadFile(string type, Guid Id, string fileExtension, byte[] image)
        {
            Stream imageStream = new MemoryStream(image);
            string photoUrl = await ImageRepository.UploadFile(type, Id, fileExtension, imageStream);
            return photoUrl;
        }
    }
}
