using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class userHistory
    {
        public string? Uid { get; set; }
        public DateOnly Date { get; set; }
        public string? SearchInput { get; set; }
        
    }
}
