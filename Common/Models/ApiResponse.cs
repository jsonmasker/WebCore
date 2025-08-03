namespace Common.Models
{
    public sealed class ApiResponse<T>
    {
        public bool Success { get; private set; }
        public string? Message { get; private set; }
        public T Data { get; private set; }
        public ApiResponse(bool success, string? message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
    public sealed class ApiResponse
    {
        public bool Success { get; private set; }
        public string? Message { get; private set; }
        public ApiResponse(bool success, string? message)
        {
            Success = success;
            Message = message;
        }
    }
}
