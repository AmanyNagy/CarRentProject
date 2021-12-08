using System;
namespace CarRent3.Profile
{
    public class CarModelProfile : AutoMapper.Profile
    {
        public CarModelProfile()
        {
            CreateMap<Model.VwDistinctModel, Dto.CarModelDto>();
        }
    }
}
