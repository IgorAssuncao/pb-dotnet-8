using System;
using System.IO;

namespace Repositories
{
    public interface IImageRepository
    {
        void UploadFile(Guid userId, Stream imageStream);
    }
}
