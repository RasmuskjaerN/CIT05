using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class userRate
    {
        [Key]
        public int? Uid { get; set; }
        public string? Tconst { get; set; }
        public int? Rating { get; set; }
        public userMain? UserMain { get; set; }

    }
}
