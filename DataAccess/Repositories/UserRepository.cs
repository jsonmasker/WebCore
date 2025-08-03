using DataAccess.DTOs;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository : GenericRepository<UserDTO>, IUserRepository
    {
        private DbSet<UserDTO> _accounts;
        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _accounts = dbContext.Set<UserDTO>();
        }

        public async Task<int> GetMallIdAsync(string userName)
        {

            var data = await _accounts.FirstOrDefaultAsync(x => x.UserName == userName);
            return -1;

        }
    }
}
