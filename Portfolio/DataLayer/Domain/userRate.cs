using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class userRate
    {
        public int? Uid { get; set; }
        public string? Tconst { get; set; }
        public int? Rate { get; set; }
        public userMain? UserMain { get; set; }
        public titleBasic TitleBasic { get; set; }
    }
}
