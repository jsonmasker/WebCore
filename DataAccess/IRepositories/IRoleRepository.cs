using DataAccess.DTOs;

namespace DataAccess.IRepositories
{
    public interface IRoleRepository : IGenericRepository<RoleDTO>
    {
        //public Task<RoleDTO> GetEagerRoleByIdAsync(int id);
    }
}
