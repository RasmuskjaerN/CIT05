using System.ComponentModel.DataAnnotations;

namespace WebServer.Models
{
    public class AkaAttributeModel
    {
        [Key]
        public string? Url { get; set; }
        public int Ordering { get; set; }
        public string? Attribute { get; set; }
    }
}
