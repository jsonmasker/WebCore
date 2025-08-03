using Microsoft.AspNetCore.Identity;

namespace DataAccess.DTOs
{
    public class UserDTO : IdentityUser<int>
    {
        public string? FullName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public IEnumerable<NotificationDTO> Notifications { get; set; }
        public UserDTO()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
            Notifications = new List<NotificationDTO>();
        }
    }
}
