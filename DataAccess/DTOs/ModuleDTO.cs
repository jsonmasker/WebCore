namespace DataAccess.DTOs
{
    public class ModuleDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int Priority { get; set; }
        public ICollection<ControllerDTO> Controllers { get; set; }
        public ModuleDTO()
        {
            Name = string.Empty;
            Label = string.Empty;
            Controllers = new List<ControllerDTO>();
        }
    }
}
