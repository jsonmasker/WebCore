using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<RoleDTO>
    {
        public void Configure(EntityTypeBuilder<RoleDTO> builder)
        {
            builder.ToTable("TBSytem_Roles");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.HasData([
                new RoleDTO { Id = 1, Name = "Admin", NormalizedName = "Admin".ToUpper(), Description = "System Admin Role",  CreatedBy = "System", ModifiedBy = "System", IsSystemRole = true },
                ]);
        }
    }
}
