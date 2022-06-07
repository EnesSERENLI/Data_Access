using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerDB.Entity
{
    public class Extra:BaseEntity
    {
        public Extra()
        {
            IsActive = true;
        }
        public override int ID { get; set; }
        public override string Name { get; set; }
        public override decimal Price { get; set; }
        public override bool IsActive { get; set; }

        //Mapping
        public virtual List<Order_Detail> Order_Details { get; set; }

    }
}
