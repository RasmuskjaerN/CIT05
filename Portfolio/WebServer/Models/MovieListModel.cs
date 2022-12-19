using DataLayer.Domain;

namespace WebServer.Models
{
    public class MovieListModel
    {
        public string? Url { get; set; }
        public string? PrimaryTitle { get; set; }
        public string? StartYear { get; set; }
        public string? Genre { get; set; }
        public IList<MoviePosterListModel>? OmdbData { get; set; }
        public IList<MovieRatingListModel>? TitleRating { get; set; }

    }
    public class MoviePosterListModel
    {
        public string? Poster { get; set; }
    }
    public class MovieRatingListModel
    {
        public float? AverageRating { get; set; }
        public int? NumVotes { get; set; }
    }
}
