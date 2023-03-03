namespace Application.Common.Utils
{
    public class ApiResponseUtils
    {
        public ApiResponseUtils()
        {
        }
        public ApiResponseUtils(bool success, string message, object data)
        {
            Data = data;
            Success = success;
            Message = message;
        }
        public ApiResponseUtils(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
