using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerDB.Entity
{
    public class Hamburger :BaseEntity
    {
        public Hamburger() //Constructor
        {
            IsActive = true; //It will be active first each time a new hamburger is added. It can then be deactivated and removed from the list if desired.
        }
        public override int ID { get; set; }
        public override string Name { get; set; }
        public override decimal Price { get; set; }
        public override bool IsActive { get; set; }

        //Mapping

        //Lazy Loading
        public virtual List<Order> Orders { get; set; }
    }
}
