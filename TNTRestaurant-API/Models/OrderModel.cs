﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNTRestaurant_API.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int TableID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
    }
}
