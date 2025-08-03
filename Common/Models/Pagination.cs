
namespace Common.Models
{
    public class Pagination<T> : PageInformation where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public Pagination()
        {
            Items = new List<T>();
        }
    }
}
