using System.Runtime;
using AutoMapper;
using Database.Entities;
using TNTRestaurant_API.Models;

namespace TNTRestaurant_API.Helpers
{
    public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<Product,ProductModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Restaurant,RestaurantModel>().ReverseMap();
            CreateMap<Table,TableModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailModel>().ReverseMap();
        }
    }
}
