using DataLayer.Domain;

namespace WebServer.Models
{
    public class UserModel
    {
        public string? Url { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public string? bookmarkTconst { get; set; }
        public string? bookmarkNote { get; set; }
        public string? searchDate { get; set; }
        //public List<userMain> Rating { get; set; }
        public string? SearchInput { get; set; }
        public string? rateTconst { get; set; }
        public int? Rating { get; set; }
    }
}
