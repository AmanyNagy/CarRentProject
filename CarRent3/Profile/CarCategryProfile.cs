using System;
namespace CarRent3.Profile
{
    public class CarCategryProfile : AutoMapper.Profile
    {
        public CarCategryProfile()
        {
            CreateMap<Model.VwDistinctCategory, Dto.CarCategoriesDto>();
        }
    }
}
