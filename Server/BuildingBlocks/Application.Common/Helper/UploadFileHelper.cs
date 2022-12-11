using Microsoft.AspNetCore.Http;

namespace Application.Common.Helper
{
    public static class UploadFileHelper
    {
        private static string Dir = System.IO.Directory.GetCurrentDirectory();
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
                    if (!Directory.Exists(Dir + "\\Images\\" + $"\\{locationStorage}\\"))
                    // Kiểm tra xem đã tồn tại thư mục chưa
                    {
                        Directory.CreateDirectory(Dir + "\\Images\\" + $"\\{locationStorage}\\");
                    }
                    var fileStream = System.IO.File.Create(Dir + "\\Images\\" + $"\\{locationStorage}\\" + file.FileName);

                    await file.CopyToAsync(fileStream);
                    await fileStream.FlushAsync(); // giải phóng bộ đệm


                    // Mã hóa base64 cho sản phẩm
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
            else {
                return "Không Up được file";
            }
        }
        public static void DeleteImage(string imageName, string locationStorage)
        {
            var imagePath = Path.Combine(Dir + "\\Images\\" + $"\\{locationStorage}\\" + imageName);
            if (System.IO.File.Exists(imagePath)) {
                System.IO.File.Delete(imagePath);
            }

        }
    }
}