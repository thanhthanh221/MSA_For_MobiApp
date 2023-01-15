namespace Identity.Domain.Services
{
    public class ResponseClient
    {
        public ResponseClient()
        {
        }

        public ResponseClient(object response, int status)
        {
            Response = response;
            Status = status;
        }

        public ResponseClient(object response, int status, bool verify) : this(response, status)
        {
            Verify = verify;
        }

        public object Response { get; set; }
        public int Status { get; set; }
        public bool Verify {get; set;} 
    }
}
