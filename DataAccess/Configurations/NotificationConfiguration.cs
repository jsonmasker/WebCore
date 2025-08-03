using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class NotificationConfiguration : IEntityTypeConfiguration<NotificationDTO>
    {
        public void Configure(EntityTypeBuilder<NotificationDTO> builder)
        {
            builder.ToTable("TBSytem_Notifications");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
        }
    }
}
