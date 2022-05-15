﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Week:BaseEntity
    {
        public int ID { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }

        //Mapping
        public List<Theather> Theathers { get; set; }
    }
}
