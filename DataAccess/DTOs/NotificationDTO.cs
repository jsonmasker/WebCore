namespace DataAccess.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserDTO User { get; set; }
        public NotificationDTO()
        {
            Message = string.Empty;
            CreatedOn = DateTime.Now;
            User = new UserDTO();
        }
    }
}
