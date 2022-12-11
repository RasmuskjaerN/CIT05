using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebServer.Models
{
    public class UserLoginModel
    {

        public string? UserName { get; set; }
        public string? Password { get; set; }
        //public string Hash { get; set; }
    }
}
