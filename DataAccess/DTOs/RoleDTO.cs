using Microsoft.AspNetCore.Identity;

namespace DataAccess.DTOs
{
    public class RoleDTO : IdentityRole<int>
    {
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsSystemRole { get; set; }
        public ICollection<RoleClaimDTO> RoleClaims { get; set; }
        public RoleDTO()
        {
            IsDeleted = false;
            IsActive = true;
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
            RoleClaims = new List<RoleClaimDTO>();
        }
    }
}
