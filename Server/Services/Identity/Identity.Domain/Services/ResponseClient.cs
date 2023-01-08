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

        public ResponseClient(string message, int status, bool verify) : this(message, status)
        {
            Verify = verify;
        }

        public string Message { get; set; }
        public int Status { get; set; }
        public bool Verify {get; set;} 
    }
}
