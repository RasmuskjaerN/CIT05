using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class titleRating
    {
        public string Tconst { get; set; }
        public float? AverageRating { get; set; }
        public int? NumVotes { get; set; }
        public titleBasic? TitleBasic { get; set; }
        
    }
}
