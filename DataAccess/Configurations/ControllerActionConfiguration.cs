using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ControllerActionConfiguration : IEntityTypeConfiguration<ControllerActionDTO>
    {
        public void Configure(EntityTypeBuilder<ControllerActionDTO> builder)
        {
            builder.ToTable("TBSytem_ControllerActions");
            builder.HasKey(s => new { s.ControllerId, s.ActionId });
            builder.HasOne(s => s.Controller)
                .WithMany(g => g.ControllerActions)
                .HasForeignKey(s => s.ControllerId);
            builder.HasOne(s => s.Action)
                .WithMany(g => g.ControllerActions)
                .HasForeignKey(s => s.ActionId);
        }
    }
}
