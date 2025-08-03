using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class SingleMailData
    {
        [Required]
        [EmailAddress]
        public string To { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public IFormFileCollection? Attachments { get; set; }
    }
}
