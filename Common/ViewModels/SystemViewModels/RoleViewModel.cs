using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels.SystemViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public List<SelectedRoleClaimViewModel> SelectedRoleClaims { get; set; }
        public RoleViewModel()
        {
            IsActive = true;
            SelectedRoleClaims = new List<SelectedRoleClaimViewModel>();
        }
    }
    public class SelectedRoleClaimViewModel
    {
        public int Id { get; set; }
        public int RoleClaimGroupId { get; set; }
        public int RoleClaimId { get; set; }
    }
}
