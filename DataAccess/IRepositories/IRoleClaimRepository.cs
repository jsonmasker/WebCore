using DataAccess.DTOs;

namespace DataAccess.IRepositories
{
    public interface IRoleClaimRepository : IGenericRepository<RoleClaimDTO>
    {
        Task RemoveSelectedRoleClaimByRoleID(int roleID);
    }
}
