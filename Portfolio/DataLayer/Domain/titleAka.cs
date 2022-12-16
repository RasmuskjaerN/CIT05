using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class titleAka
    {
        public string? Tconst { get; set; }
        public int Ordering { get; set; }
        public string? Title { get; set; }
        public string? Region { get; set; }
        public string? Language { get; set; }
        public string? Type { get; set; }
        public string? Attribute { get; set; }
        public bool IsOriginalTitle { get; set; }
        public virtual titleBasic? titles { get; set; }
    }
}
