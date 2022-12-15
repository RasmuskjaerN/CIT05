using DataLayer.Domain;

namespace WebServer.Models
{
    public class UserModel
    {
        public string? Url { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public virtual List<userBookmark>? Bookmarks { get; set; }
        public virtual List<userHistory>? History { get; set; }
        public virtual List<userRate>? Ratings { get; set; }
    }
}
