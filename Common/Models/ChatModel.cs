using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class ChatModel
    {
        [Required]
        public required string Request { get; set; }
        [Required]
        public required string Model { get; set; }
        public string? Response { get; set; }
        public IList<long>? Context { get; set; }
        public bool Stream { get; set; } = false;
    }
}
