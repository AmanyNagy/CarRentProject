using System;
namespace CarRent3.Profile
{
    public class CarProfile : AutoMapper.Profile
    {
        public CarProfile()
        {
            CreateMap<Model.Car, Dto.CarDto>(); 
        }
    }
}
