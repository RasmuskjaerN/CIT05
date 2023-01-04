using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class nameBasic
    {
        public string? Nconst { get; set; }
        public string? PrimaryName { get; set; }
        public string? Birthyear { get; set; }
        public string? Deathyear { get; set; }
        public float? NameRating { get; set; }
        public IList<Role>? Character { get; set; }
        
    }
}
