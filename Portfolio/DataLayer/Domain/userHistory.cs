using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class userHistory
    {
<<<<<<< HEAD
       
        public string? Uid { get; set; }
        public DateOnly Date { get; set; }
        public string? SearchInput { get; set; }
=======
        public int? Uid { get; set; }
        public DateOnly? Date { get; set; }
        public string? SearchInput { get; set; }
        public userMain? UserMain { get; set; }


>>>>>>> f9e92dab41f4aaff27c0606ee026f07218cbe348
    }
}
