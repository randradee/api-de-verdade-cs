namespace api_de_verdade.Domain.Services.Communication
{
    public class Response<T>
    {
        public bool Success { get; init; }
        public string Message { get; init; }
        public T? Resource { get; init; }

        public Response(bool success, string message, T? resource)
        {
            Success = success;
            Message = message;
            Resource = resource;
        }
        public Response(T? resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        public Response(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
    }
}
