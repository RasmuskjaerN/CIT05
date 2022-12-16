using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
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
        public int? Uid { get; set; }
        public DateOnly? Date { get; set; }
        public string? SearchInput { get; set; }
        


    }
}
