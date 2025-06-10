using Trizen.Infrastructure.Base.File;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Infrastructure.Utilities;

public class FileUtility : IFileUtility
{
    public async Task<Response<string>> UploadFileLocal(UploadFileDto dto)
    {
        try
        {
            string fileName = $"{Guid.NewGuid()}__{dto.File.FileName}";
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", dto.Entity);
            string originalPath = Path.Combine(directoryPath, fileName);

            await using (FileStream stream = new(originalPath, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            return Response<string>.SuccessResult(fileName);
        }
        catch (Exception) { }

        return Response<string>.FailResult(null);
    }

    public bool DeleteFileLocal(DeleteFileDto dto)
    {
        try
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", dto.Entity);
            string originalPath = Path.Combine(directoryPath, dto.FileName);
            if (File.Exists(originalPath))
            {
                File.Delete(originalPath);
            }

            return true;
        }
        catch (Exception) { }

        return false;
    }
}