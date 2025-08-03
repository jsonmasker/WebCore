using DataAccess.DTOs;
using DataAccess.IRepositories;

namespace DataAccess.Repositories
{
    public class ActionRepository : GenericRepository<ActionDTO>, IActionRepository
    {
        public ActionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
