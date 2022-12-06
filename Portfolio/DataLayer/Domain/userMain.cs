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
        public string? UserName { get; set; }
        public string? Password { get; set; }
        /*public string Salt { get; set; }
        public bool admin { get; set; } = false;
        public List<userRate> rates { get; set; }
        public List<userBookmark> bookmarks { get; set; }
        public List<userHistory> history { get; set; }*/

    }
}
