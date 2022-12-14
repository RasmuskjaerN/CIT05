using DataLayer.Domain;

namespace WebServer.Models
{
    public class MovieModel
    {
        public string? Url { get; set; }
        public string? TitleType { get; set; }
        public string? PrimaryTitle { get; set; }
        public string? OriginalTitle { get; set; }
        public bool? IsAdult { get; set; }
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public int? RunTimeMinutes { get; set; }
        public string? Genre { get; set; }
        public IList<movieomdbmodel>? OmdbData { get; set; }
        public IList<movietitleakasmodel>? TitleAkas { get; set; }
        public IList<titleRating>? TitleRating { get; set; }
        public IList<movieuserbookmarkmodel>? UserBookmarks { get; set; }
        public IList<movieuserratingmodel>? UserRating { get; set; }
    }
    public class movieomdbmodel
    {
        public string? Poster { get; set; }
        public string? Plot { get; set; }
    }
    public class movieuserbookmarkmodel
    {
        public int? Uid { get; set; }
        public string? userbookmarkNote { get; set; }
    }
    public class movieuserratingmodel
    {
        public int? Uid { get; set; }
        public int? userratingRate { get; set; }
    }
    public class movietitleakasmodel
    {
        public int? Ordering { get; set; } 
        public string? Title { get; set; }
        public string? Region { get; set; }
        public string? Language { get; set; }    
        public string? Type { get; set; }
        public string? Attributes { get; set; }
        public bool? IsOriginalTitle { get; set; }
    }
    public class movietitleratingmodel
    {
        public float? AverageRating { get; set; }
        public int? NumVotes { get; set; }
    }
    public class CreateMovieBookmarkModel
    {
        public int Uid { get; set; }
        public string Tconst { get; set; }

        public string? Note { get; set; }
    }

}
