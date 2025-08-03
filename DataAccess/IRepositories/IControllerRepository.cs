using DataAccess.DTOs;

namespace DataAccess.IRepositories
{
    public interface IControllerRepository : IGenericRepository<ControllerDTO>
    {
        //public Task<IEnumerable<ControllerDTO>> GetEagerClaimGroupAllAsync();
    }
}
