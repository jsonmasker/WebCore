using DataAccess.DTOs;

namespace DataAccess.IRepositories
{
    public interface IModuleRepository : IGenericRepository<ModuleDTO>
    {
        public Task<ICollection<ModuleDTO>> GetEagerAllAsync();
    }
}
