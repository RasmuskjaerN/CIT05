﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{

    public class Role
    {
        public string? Nconst { get; set; }
        public string? Tconst { get; set; }
        public string? Character { get; set; }
        public nameBasic? NameBasic { get; set; }
        public titleBasic? TitleBasic { get; set; }
    }
}
