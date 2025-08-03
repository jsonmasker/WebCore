using DataAccess.DTOs;

namespace DataAccess.IRepositories
{
    public interface IUserTokenRepository : IGenericRepository<UserTokenDTO>
    {
        public Task<UserTokenDTO> GetUserTokenByRefreshToken(string refreshToken);
    }
}
