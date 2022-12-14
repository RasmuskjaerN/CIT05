using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class omdbData
    {
        public string? Tconst { get; set; }
        public string? Poster { get; set; }
        public string? Plot { get; set; }
        public virtual titleBasic? titles { get; set; }


    }
}
