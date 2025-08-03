namespace Common.Models
{
    public class DataObjectResult
    {
        public bool OK { get; set; }
        public string? Message { get; set; }
        public string? Data { get; set; }
        public DataObjectResult()
        {
            OK = false;
        }
    }
}
