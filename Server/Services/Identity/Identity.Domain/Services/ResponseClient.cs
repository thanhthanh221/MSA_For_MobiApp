namespace Identity.Domain.Services
{
    public class ResponseClient
    {
        public ResponseClient()
        {
        }

        public ResponseClient(string message, int status)
        {
            Message = message;
            Status = status;
        }

        public string Message { get; set; }
        public int Status { get; set; }
    }
}
