using Microsoft.AspNetCore.Identity;

namespace DataAccess.DTOs
{
    public class UserTokenDTO : IdentityUserToken<int>
    {
        public DateTime ExpirationTime { get; set; }
    }
}
