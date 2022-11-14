
using System.ComponentModel.DataAnnotations;


namespace DataLayer.Domain
{

    public class akaAttribute
    {
        [Key]
        public string? Tconst { get; set; }
        public int Ordering { get; set; }
        public string? Attribute { get; set; }
    }
}
