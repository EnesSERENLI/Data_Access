using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerDB.Entity
{
    public class Dimension
    {
        public int DimensionID { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }

        //Mapping
        public List<Order_Detail> Order_Details { get; set; }
    }
}
