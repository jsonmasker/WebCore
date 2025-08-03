using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDTO>
    {
        public void Configure(EntityTypeBuilder<UserDTO> builder)
        {
            builder.ToTable("TBSystem_Users");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.CreatedOn).IsRequired();
            builder.Property(s => s.ModifiedOn).IsRequired();
            builder.Property(s => s.Email).IsRequired();
            builder.HasIndex(s => s.Email).IsUnique();
            builder.HasData([new UserDTO()
            {
                Id = 1,
                FullName = "System Administrator",
                Email = "jsonmasker@gmail.com",
                UserName = "admin",
                NormalizedUserName ="ADMIN",
                NormalizedEmail = "JSONMASKER@GMAIL.COM",
                PasswordHash = "AQAAAAIAAYagAAAAEB0Hdhuj4HcnoBu9LWgJK4dnP9DqV8kiBJBnNBsEAZSgpPaW+401U1IHYk43xxFi0g==",
                SecurityStamp = "I665EUWG7LEWP6W6YKD2GEI5DWUK2KCE",
                ConcurrencyStamp = "d8fb4ea3-3b74-40c4-ba5f-a35d02fc1566",
                CreatedBy = "System",
                ModifiedBy = "System",
                IsActive = true,
                IsDeleted = false,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            }]);
        }
    }
}
