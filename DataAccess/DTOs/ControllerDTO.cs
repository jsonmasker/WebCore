namespace DataAccess.DTOs
{
    public class ControllerDTO
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int Priority { get; set; }
        public ModuleDTO? Module { get; set; }
        public ICollection<ControllerActionDTO> ControllerActions { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public ControllerDTO()
        {
            Name = string.Empty;
            Label = string.Empty;
            ControllerActions = new List<ControllerActionDTO>();
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
            IsDeleted = false;
        }
    }
}
