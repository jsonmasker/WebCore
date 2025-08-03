using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class UserClaimConfiguration : IEntityTypeConfiguration<UserClaimDTO>
    {
        public void Configure(EntityTypeBuilder<UserClaimDTO> builder)
        {
            builder.ToTable("TBSytem_UserClaims");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
        }
    }
}
