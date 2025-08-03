namespace Common.ViewModels.SystemViewModels
{
    public class RoleClaimGroupViewModel
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<RoleClaimViewModel> RoleClaims { get; set; }
        public RoleClaimGroupViewModel()
        {
            Name = string.Empty;
            IsActive = true;
            RoleClaims = new List<RoleClaimViewModel>();
        }
    }
}
