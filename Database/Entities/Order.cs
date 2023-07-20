using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int TableID { get; set; }
        public Table Table { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
