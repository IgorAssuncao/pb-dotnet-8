using System;
using System.IO;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IImageRepository
    {
        Task<string> UploadFile(string type, Guid Id, string fileExtension, Stream imageStream);
    }
}
