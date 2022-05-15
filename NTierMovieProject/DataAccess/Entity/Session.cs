using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Session:BaseEntity
    {
        public int ID { get; set; }
        public TimeSpan Duration { get; set; }

        //Mapping
        public List<Theather> Theathers { get; set; }
    }
}
