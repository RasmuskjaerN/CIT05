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
        //public RatingModel? Rating { get; set; }
        //public virtual wi? wis { get; set; }
        public string? Plot { get; set; }
        public string? Poster { get; set; }
    }
}
