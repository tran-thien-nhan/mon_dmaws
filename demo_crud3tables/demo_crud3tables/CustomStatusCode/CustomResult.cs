namespace demo_crud3tables.CustomStatusCode
{
    public class CustomResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public CustomResult(int status, string message, object? data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
