using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    
    public class userMain
    {
        public int? Uid { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; } = String.Empty;
        public IList<userBookmark>? Bookmarks { get; set; }
        public IList <userHistory>? Histories { get; set; }
        public IList<userRate>? Ratings { get; set; }

        
    }
}
