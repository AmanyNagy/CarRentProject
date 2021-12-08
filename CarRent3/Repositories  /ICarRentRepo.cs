using System;
using System.Collections.Generic;
using CarRent3.Model;

namespace CarRent3.Repositories
{
    public interface ICarRentRepo
    {
        IEnumerable<Car> GetCars();
        IEnumerable<Car> GetCars(string catname, string modelName, bool? isAvailability);
        IEnumerable<VwDistinctModel> GetModel();
        IEnumerable<VwDistinctCategory> GetCategories();

        IEnumerable<Order> GetOrders();

    }
}
