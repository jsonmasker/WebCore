namespace DataAccess.DTOs
{
    public class ControllerActionDTO
    {
        public int ControllerId { get; set; }
        public int ActionId { get; set; }
        public ControllerDTO? Controller { get; set; }
        public ActionDTO? Action { get; set; }
    }
}
