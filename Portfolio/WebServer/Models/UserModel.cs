using DataLayer.Domain;

namespace WebServer.Models
{
    public class UserModel
    {
        public string? Url { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public IList<userHistory> userHistories { get; set; }
    }
}
