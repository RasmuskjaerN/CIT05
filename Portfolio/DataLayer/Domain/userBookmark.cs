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
        public int? Uid { get; set; }
        public string? Tconst { get; set; }
        public string? Note { get; set; }
        public userMain? UserMain { get; set; }
        public titleBasic? TitleBasic { get; set; }
    }
}
