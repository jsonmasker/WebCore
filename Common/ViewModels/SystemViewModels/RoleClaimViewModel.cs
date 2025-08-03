using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SystemViewModels
{
    public class RoleClaimViewModel
    {
        public int Id { get; set; }
        public int RoleClaimGroupId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public RoleClaimViewModel()
        {
            Name = string.Empty;
            IsActive = true;
        }
    }
}
