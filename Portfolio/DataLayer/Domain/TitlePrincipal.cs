using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class titlePrincipal
    {
        public string? Tconst { get; set; }
        public int Ordering { get; set; }
        public string? Nconst { get; set; }
        public string? Category { get; set; }
        public string? Job { get; set; }
    }
}
