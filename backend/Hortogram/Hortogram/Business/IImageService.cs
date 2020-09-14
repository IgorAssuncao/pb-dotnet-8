using System;
using System.IO;

namespace Services
{
    public interface IImageService
    {
        void UploadFile(Guid userId, Stream image);
    }
}
