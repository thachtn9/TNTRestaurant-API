using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Table
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Order> Orders { get; set; }
    }
}
