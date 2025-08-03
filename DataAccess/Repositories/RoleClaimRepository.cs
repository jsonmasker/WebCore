using DataAccess.DTOs;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RoleClaimRepository : GenericRepository<RoleClaimDTO>, IRoleClaimRepository
    {
        private readonly DbSet<RoleClaimDTO> _selectedRoleClaims;
        public RoleClaimRepository(ApplicationContext context) : base(context)
        {
            _selectedRoleClaims = context.Set<RoleClaimDTO>();
        }

        public async Task RemoveSelectedRoleClaimByRoleID(int roleID)
        {
            var data = await _selectedRoleClaims.Where(src => src.RoleId == roleID).ToListAsync();
            data.ForEach(src => _selectedRoleClaims.Remove(src));
        }
    }
}
