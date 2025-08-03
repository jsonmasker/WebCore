using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaimDTO>
    {
        public void Configure(EntityTypeBuilder<RoleClaimDTO> builder)
        {
            builder.ToTable("TBSystem_RoleClaims");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.RoleClaimId).IsRequired();
            builder.Property(s => s.RoleId).IsRequired();
            builder.HasOne(s => s.Role).WithMany(r => r.RoleClaims).HasForeignKey(s => s.RoleId);
        }
    }
}
