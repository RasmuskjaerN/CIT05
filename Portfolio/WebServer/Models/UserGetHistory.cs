using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Models
{
    public class UserGetHistory
    {

        public string Url { get; set; }
        public string Uid { get; set; }
        public DateOnly Date { get; set; }
        public string? SearchInput { get; set; }
        public UserModel User { get; set; }
    }
}
