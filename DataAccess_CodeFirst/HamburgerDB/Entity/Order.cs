using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerDB.Entity
{
    public class Order
    {
        public Order()
        {
            OrderDate = DateTime.Now;
        }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal KDVPrice
        {
            get { return TotalPrice * 1.18m; }
        }

        //MApping
        public int HamburgerId { get; set; }
        public virtual Hamburger Hamburger { get; set; }
        public virtual List<Order_Detail> Order_Details { get; set; }

    }
}
