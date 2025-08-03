using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class UserLoginConfiguration : IEntityTypeConfiguration<UserLoginDTO>
    {
        public void Configure(EntityTypeBuilder<UserLoginDTO> builder)
        {
            builder.ToTable("TBSytem_UserLogins");
        }
    }
}
