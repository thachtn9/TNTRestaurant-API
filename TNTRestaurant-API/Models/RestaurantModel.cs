using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNTRestaurant_API.Models
{
    public class RestaurantModel
    {
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantLocation { get; set; }
        public List<TableModel>? Tables { get; set; }    
    }
}
