using DataAccess.DTOs;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserTokenRepository : GenericRepository<UserTokenDTO>, IUserTokenRepository
    {
        private DbSet<UserTokenDTO> UserTokens;
        public UserTokenRepository(ApplicationContext context) : base(context)
        {
            UserTokens = context.Set<UserTokenDTO>();
        }

        public async Task<UserTokenDTO> GetUserTokenByRefreshToken(string refreshToken)
        {
            return await UserTokens.Where(s => string.Equals(s.Value, refreshToken)).FirstOrDefaultAsync();
        }
    }
}
