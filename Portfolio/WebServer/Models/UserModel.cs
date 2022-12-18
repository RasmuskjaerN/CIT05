using DataLayer.Domain;

namespace WebServer.Models
{
    public class UserModel
    {
        public string? Url { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
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
    public class UserCreateBookmark
    {
        public int UserId { get; set; }
        public string Tconst { get; set; }
        public string? Note { get; set; }
    }
    public class UserCreateModel
    {
        public int? Uid { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
    }
    public class UserLoginModel
    {

        public string? UserName { get; set; }
        public string? Password { get; set; }

    }
    public class UserGetHistory
    {

        public string Url { get; set; }
        public string Uid { get; set; }
        public string? Date { get; set; }
        public string? SearchInput { get; set; }
    }
    public class UserDeleteBookmark
    {
        public string UserId { get; set; }
        public string Tconst { get; set; }
    }

}
