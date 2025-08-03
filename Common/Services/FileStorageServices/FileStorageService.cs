using Common.Custom.ExtensionMethods;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SkiaSharp;

namespace Common.Services.FileStorageServices
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        /// <summary>
        /// Check if the file is an file
        /// </summary>
        /// <param name="file">".pdf", ".doc", ".docx", ".xls", ".xlsx"</param>
        /// <returns>boolean</returns>
        /// <exception cref="ArgumentException"></exception>
        public bool IsDocFile(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentException("Invalid file provided");
            }
            string[] permittedExtensions = { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return !string.IsNullOrEmpty(extension) && permittedExtensions.Contains(extension);
        }

        /// <summary>
        /// Check if the file is an image
        /// </summary>
        /// <param name="file">".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp"</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool IsImageFile(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentException("Invalid file provided");
            }
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return !string.IsNullOrEmpty(extension) && permittedExtensions.Contains(extension);
        }
        /// <summary>
        /// Save image to the specified folder in WebP format
        /// Return the file name of the file
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public string SaveImageToWebp(string[] paths, IFormFile file)
        {
            if (file == null || paths == null || paths.Length == 0)
            {
                throw new ArgumentException("Invalid arguments provided");
            }
            if (!IsImageFile(file))
            {
                throw new ArgumentException("Invalid file provided");
            }

            string path = Path.Combine(_webHostEnvironment.WebRootPath, Path.Combine(paths));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = string.Concat(Guid.NewGuid(), Path.GetExtension(file.FileName)).ToFormatFileNameString();
            string imagePath = Path.Combine(path, fileName);

            using (var stream = file.OpenReadStream())
            {
                using (var originalImage = SKBitmap.Decode(stream))
                {
                    if (originalImage == null)
                    {
                        throw new InvalidOperationException("Unable to decode the image.");
                    }

                    using (var image = SKImage.FromBitmap(originalImage))
                    using (var data = image.Encode(SKEncodedImageFormat.Webp, 80)) // 80 is the quality (0-100)
                    using (var fileStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                    {
                        data.SaveTo(fileStream);
                    }
                }
            }

            return Path.Combine(Path.Combine(paths), fileName);
        }

        public string SaveImageFile(string[] paths, IFormFile file)
        {
            if (file == null || paths == null || paths.Length == 0)
            {
                throw new ArgumentException("Invalid arguments provided");
            }
            if (!IsImageFile(file))
            {
                throw new ArgumentException("Invalid file provided");
            }
            return SaveFile(paths, file);
        }

        public string SaveDocFile(string[] paths, IFormFile file)
        {
            if (file == null || paths == null || paths.Length == 0)
            {
                throw new ArgumentException("Invalid arguments provided");
            }
            if (!IsDocFile(file))
            {
                throw new ArgumentException("Invalid file provided");
            }
            return SaveFile(paths, file);
        }

        public void DeleteFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Invalid arguments provided");
            }
            string path = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private string SaveFile(string[] paths, IFormFile file)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, Path.Combine(paths));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName = string.Concat(Guid.NewGuid(), Path.GetExtension(file.FileName)).ToFormatFileNameString();
            string imagePath = Path.Combine(path, fileName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return Path.Combine(Path.Combine(paths), fileName);
        }
    }
}
