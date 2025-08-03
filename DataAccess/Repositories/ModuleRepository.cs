using DataAccess.DTOs;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ModuleRepository : GenericRepository<ModuleDTO>, IModuleRepository
    {
        private readonly DbSet<ModuleDTO> modules;
        public ModuleRepository(ApplicationContext context) : base(context)
        {
            modules = context.Set<ModuleDTO>();
        }

        public async Task<ICollection<ModuleDTO>> GetEagerAllAsync()
        {
            ICollection<ModuleDTO> data = await modules.Include(s => s.Controllers).ThenInclude(s => s.ControllerActions).ToListAsync();
            return data;
        }
    }
}
