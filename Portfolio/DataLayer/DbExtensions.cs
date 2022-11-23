using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{    
    public static class DbExtensions
    {

        public static object ExecuteScalar(this IMDBContext ctx, string sql)
        {
            var conn = (NpgsqlConnection)ctx.Database.GetDbConnection();
            conn.Open();

            var cmd = new NpgsqlCommand(sql, conn);
            return cmd.ExecuteScalar();
        }
    }
    
}
