using Microsoft.AspNetCore.Http;

namespace Common.Services.FileStorageServices
{
    public interface IFileStorageService
    {
        public bool IsImageFile(IFormFile file);
        public bool IsDocFile(IFormFile file);
        public string SaveDocFile(string[] paths, IFormFile file);
        public string SaveImageFile(string[] paths, IFormFile file);
        public string SaveImageToWebp(string[] paths, IFormFile file);
        public void DeleteFile(string filePath);
    }
}
