﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersCrudOperations
{
    public class User
    {
        public int id { get; set; }
        public string nickName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
    }
}
