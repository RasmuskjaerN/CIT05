using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class userMain
    {
        public string? Uid { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
