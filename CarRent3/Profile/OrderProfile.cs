using System;
namespace CarRent3.Profile
{
    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<Model.Order, Dto.OrderDto>();
        }
    }
}
