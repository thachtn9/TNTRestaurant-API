using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNTRestaurant_API.Models
{
    public class TableModel
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public int RestaurantID { get; set; }
    }
}
