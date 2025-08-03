using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class UserTokenConfiguration : IEntityTypeConfiguration<UserTokenDTO>
    {
        public void Configure(EntityTypeBuilder<UserTokenDTO> builder)
        {
            builder.ToTable("TBSytem_UserTokens");
        }
    }
}
