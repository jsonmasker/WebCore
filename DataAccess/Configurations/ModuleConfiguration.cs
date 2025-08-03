using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class ModuleConfiguration : IEntityTypeConfiguration<ModuleDTO>
    {
        public void Configure(EntityTypeBuilder<ModuleDTO> builder)
        {
            builder.ToTable("TBSytem_Modules");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
        }
    }
}
