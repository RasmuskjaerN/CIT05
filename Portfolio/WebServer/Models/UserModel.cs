using DataLayer.Domain;

namespace WebServer.Models
{
    public class UserModel
    {
        public string? Url { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        //public UserGetHistory? UserHistory { get; set; }
        

        public string? Salt { get; set; }
        public List<userbookmarkmodel>? Bookmarks { get; set; }
        public List<userhistorymodel>? Histories { get; set; }
        public List<userratingmodel>? Ratings { get; set; }
    }
    public class userbookmarkmodel
    {
        public string bookmarkTconst { get; set; }
        public string bookmarkNote { get; set; }
    }
    public class userhistorymodel
    {
        public string historyDate { get; set; }
        public string historySearchInput { get; set; }
    }
    public class userratingmodel
    {
        public string? ratingTconst { get; set; }
        public int? ratingRate { get; set; }
    }

}
