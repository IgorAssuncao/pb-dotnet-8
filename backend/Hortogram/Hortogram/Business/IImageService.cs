using System;
using System.IO;

namespace Services
{
    public interface IImageService
    {
        string UploadFile(string type, Guid Id, string fileExtension, byte[] image);
    }
}
