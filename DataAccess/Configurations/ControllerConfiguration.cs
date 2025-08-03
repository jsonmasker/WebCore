using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class ControllerConfiguration : IEntityTypeConfiguration<ControllerDTO>
    {
        public void Configure(EntityTypeBuilder<ControllerDTO> builder)
        {
            builder.ToTable("TBSytem_Controllers");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Name).IsRequired();
            // Set Name as unique
            builder.HasIndex(s => s.Name).IsUnique();
            builder.Property(s => s.CreatedOn).IsRequired();
            builder.Property(s => s.ModifiedOn).IsRequired();
            builder.Property(s => s.IsDeleted).HasDefaultValue(false);
            builder.HasOne(s => s.Module)
               .WithMany(g => g.Controllers)
               .HasForeignKey(s => s.ModuleId);
        }
    }
}
