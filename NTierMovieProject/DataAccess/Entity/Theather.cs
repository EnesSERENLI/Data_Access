using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Theather:BaseEntity
    {
        public int ID { get; set; }

        //Mapping
        public int MovieId { get; set; }
        public int SaloonId { get; set; }
        public int WeekId { get; set; }
        public int SessionId { get; set; }
        
        public Movie Movie { get; set; }
        public Week Week { get; set; }
        public Session Session { get; set; }
        public Saloon Saloon { get; set; }

    }
}
