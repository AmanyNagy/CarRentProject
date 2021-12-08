using System;
using System.Collections.Generic;
using System.Linq;
using CarRent3.Model;

namespace CarRent3.Repositories
{
    public class CarRentRepo : ICarRentRepo
    {
        private readonly CarRentdbContext _context;

        public CarRentRepo(CarRentdbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Car> GetCars()
        {
            return _context.Cars.ToList<Car>();
        }

        public IEnumerable<Car> GetCars(string catname, string modelName, bool? isAvailability)
        {
            if (string.IsNullOrWhiteSpace(catname)
                && string.IsNullOrWhiteSpace(modelName)
                && isAvailability == null )
            {
                return GetCars();
            }

            var collection = _context.Cars as IQueryable<Car>;

            if (isAvailability != null)
            {
                collection = (from c in _context.Cars
                              join inv in _context.Inventories on c.CarId equals inv.CarId
                              where inv.Availability == isAvailability
                              select c);
            }

            if (!string.IsNullOrWhiteSpace(catname))
            {
                catname = catname.Trim();
                collection = collection.Where(x => x.Categoryname == catname);
            }

            if (!string.IsNullOrWhiteSpace(modelName))
            {
                modelName = modelName.Trim();
                collection = collection.Where(x => x.Model == modelName);
            }

            return collection.ToList();

        }

        public IEnumerable<VwDistinctModel> GetModel()
        {

            return _context.VwDistinctModels.ToList();

        }

        public IEnumerable<VwDistinctCategory> GetCategories()
        {
            return _context.VwDistinctCategories.ToList();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }



    }
}
