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
<<<<<<< HEAD
        public string? Tconst { get; set; }
=======
        public string Tconst { get; set; }
        //public string? Nconst { get; set; }
>>>>>>> 30086cc3d512026bcb61640ad649b8a69dd763cd
        public string? Note { get; set; }
    }
}
