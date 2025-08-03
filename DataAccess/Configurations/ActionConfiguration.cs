using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class ActionConfiguration : IEntityTypeConfiguration<ActionDTO>
    {
        public void Configure(EntityTypeBuilder<ActionDTO> builder)
        {
            builder.ToTable("TBSytem_Actions");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired();
        }
    }
}
