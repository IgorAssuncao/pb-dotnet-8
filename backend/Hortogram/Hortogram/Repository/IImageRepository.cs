using System;
using System.IO;

namespace Repositories
{
    public interface IImageRepository
    {
        string UploadFile(string type, Guid Id, string fileExtension, Stream imageStream);
    }
}
