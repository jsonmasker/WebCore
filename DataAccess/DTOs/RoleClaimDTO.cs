using Microsoft.AspNetCore.Identity;

namespace DataAccess.DTOs
{
    public class RoleClaimDTO : IdentityRoleClaim<int>
    {
        public int RoleClaimGroupId { get; set; }
        public int RoleClaimId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public RoleDTO? Role { get; set; }
    }
}
