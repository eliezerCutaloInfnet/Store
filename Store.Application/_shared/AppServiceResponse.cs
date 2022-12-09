namespace Store.Application._shared
{
    public class AppServiceResponse<T> : IAppServiceResponse where T : class
    {
        #region Constructors

        public AppServiceResponse(T data, string message, bool success)
        {
            Data = data;
            Message = message;
            Success = success;
        }

        protected AppServiceResponse()
        {
        }

        #endregion Constructors

        #region Properties

        public T? Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        #endregion Properties
    }
}
