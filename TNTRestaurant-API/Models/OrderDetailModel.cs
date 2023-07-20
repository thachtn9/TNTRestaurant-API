using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNTRestaurant_API.Models
{
    public class OrderDetailModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }

    }
}
