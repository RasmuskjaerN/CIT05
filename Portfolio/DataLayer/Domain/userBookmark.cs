using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class userBookmark
    {
        public string? Uid { get; set; }
        public string? Tconst { get; set; }
        public string? Nconst { get; set; }
        public string? Note { get; set; }
    }
}
