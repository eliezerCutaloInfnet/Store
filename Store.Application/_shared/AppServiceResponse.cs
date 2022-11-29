namespace Store.Application._shared
{
    public class AppServiceResponse
    {
        public AppServiceResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
