using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class titleBasic
    {
        public string? Tconst { get; set; }
        public string? TitleType { get; set; }
        public string? PrimaryTitle { get; set; }
        public string? OriginalTitle { get; set; }
        public bool? IsAdult { get; set; }
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public int? RunTimeMinutes { get; set; }
        public string? Genre { get; set; }
        public IList<omdbData>? OmdbData { get; set; }
        public IList<titleAka>? TitleAkas { get; set; }
        public IList<titleRating>? TitleRating { get; set; }
        public IList<userBookmark>? UserBookmarks { get; set; }
        public IList<userRate>? UserRating { get; set; }
    }
}
