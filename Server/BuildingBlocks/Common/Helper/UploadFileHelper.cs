using Microsoft.AspNetCore.Http;

namespace Application.Common.Helper
{
    public static class UploadFileHelper
    {
        public static string Dir { get; set; } = Directory.GetCurrentDirectory();
        public static string IFormFileToBase64ImageOfVideo(IFormFile file)
        {
            if (file.Length > 0) {
                try {
                    MemoryStream ms = new();
                    file.CopyTo(ms);
                    byte[] fileBytes = ms.ToArray();
                    string imgToBase64 = Convert.ToBase64String(fileBytes);
                    return imgToBase64;
                }
                catch (Exception ex) {
                    return ex.ToString();
                }
            }
            return "Không up được file";
        }
        public static async Task<string> SaveImage(IFormFile file, string locationStorage)
        {
            if (file.Length > 0) {
                try {
                    if (!Directory.Exists(Dir + "\\Images\\" + $"\\{locationStorage}\\")) {
                        Directory.CreateDirectory(Dir + "\\Images\\" + $"\\{locationStorage}\\");
                    }
                    using var fileStream = File.Create(Dir + "\\Images\\" + $"\\{locationStorage}\\" + file.FileName);
                    await file.CopyToAsync(fileStream);
                    await fileStream.FlushAsync(); // giải phóng bộ đệm
                    return file.FileName;
                }
                catch (Exception ex) {
                    return ex.ToString();
                }
            }
            else {
                return "Không Up được file";
            }
        }
        public static string GetFileExtension(string fileName)
        {
            var findDotLast = fileName.LastIndexOf('.');
            if (findDotLast <= fileName.Length - 5) {
                return null;
            }
            return fileName[findDotLast..];
        }
        public static void DeleteImage(string imageName, string locationStorage)
        {
            var imagePath = Path.Combine(Dir + "\\Images\\" + $"\\{locationStorage}\\" + imageName);
            if (File.Exists(imagePath)) {
                File.Delete(imagePath);
            }
        }
        public static string GetImageMimeTypeFromImageFileExtension(string extension)
        {
            string mimetype = extension switch {
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".bmp" => "image/bmp",
                ".tiff" => "image/tiff",
                ".wmf" => "image/wmf",
                ".jp2" => "image/jp2",
                ".svg" => "image/svg+xml",
                _ => "application/octet-stream",
            };
            return mimetype;
        }
    }
}