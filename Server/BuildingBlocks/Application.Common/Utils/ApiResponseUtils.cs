namespace Application.Common.Utils
{
    public class ApiResponseUtils
    {
        public ApiResponseUtils()
        {
        }

        public ApiResponseUtils(int? status, bool success, string message)
        {
            Status = status;
            Success = success;
            Message = message;
        }
        public ApiResponseUtils(bool success, string message, object data)
        {
            Data = data;
            Success = success;
            Message = message;
        }

        public ApiResponseUtils(int? status, bool success, string message, object data) : this(status, success, message)
        {
            Data = data;
        }

        public int? Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
