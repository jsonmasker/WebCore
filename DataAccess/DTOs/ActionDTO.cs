namespace DataAccess.DTOs
{
    public class ActionDTO
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public ICollection<ControllerActionDTO> ControllerActions { get; set; }
        public ActionDTO()
        {
            Name = string.Empty;
            Label = string.Empty;
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
            ControllerActions = new List<ControllerActionDTO>();
        }
    }
}
