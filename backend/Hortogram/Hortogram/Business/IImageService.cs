using System;
using System.IO;
using System.Threading.Tasks;

namespace Services
{
    public interface IImageService
    {
        Task<string> UploadFile(string type, Guid Id, string fileExtension, byte[] image);
    }
}
