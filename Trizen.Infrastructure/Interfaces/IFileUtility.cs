using Trizen.Infrastructure.Base.File;
using Trizen.Infrastructure.Base.Response;

namespace Trizen.Infrastructure.Interfaces;

public interface IFileUtility
{
    Task<Response<string>> UploadFileLocal(UploadFileDto dto);
    bool DeleteFileLocal(DeleteFileDto dto);
}
