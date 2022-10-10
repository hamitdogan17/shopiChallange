using AutoMapper;
using Shopi.Challange.Ordering.Core;

namespace Shopi.Challange.Ordering.Business.Mapper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, Commands.AddNewOrders.OrderBody>().ReverseMap();
            CreateMap<Order, Queries.ListOfOrder.Response>().ReverseMap();
        }
    }
}
