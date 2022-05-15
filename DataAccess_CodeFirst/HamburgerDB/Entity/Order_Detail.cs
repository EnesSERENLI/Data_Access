using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerDB.Entity
{
    public class Order_Detail
    {
        public int ID { get; set; }
        public short Quantity { get; set; }

        //Mapping
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ExtraId { get; set; }
        public Extra Extra { get; set; }

        public int DimensionId { get; set; }
        public Dimension Dimension { get; set; }
    }
}
