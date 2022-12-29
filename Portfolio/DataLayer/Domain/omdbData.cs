using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public titleBasic? TitleBasic { get; set; }
    }
}
