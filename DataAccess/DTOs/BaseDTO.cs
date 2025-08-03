namespace DataAccess.DTOs
{
    public class BaseDTO
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public BaseDTO()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }
    }
}
