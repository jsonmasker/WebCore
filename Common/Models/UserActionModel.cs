using MongoDB.Bson.Serialization.Attributes;

namespace Common.Models
{
    public class UserActionModel
    {
        [BsonId]
        public string Id { get; private set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public required string ControllerName { get; set; }
        public required string ActionName { get; set; }
        public required string Status { get; set; }
        public string? Details { get; set; }
        public DateTime CreatedDate { get; private set; }
        public UserActionModel()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
        }
    }
}
