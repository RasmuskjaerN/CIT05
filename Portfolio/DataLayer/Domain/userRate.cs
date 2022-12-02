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
        public string? Uid { get; set; }
        public string? Tconst { get; set; }
        public int Rate { get; set; }
        public userMain user { get; set; }
        public titleBasic title { get; set; }
    }
}
