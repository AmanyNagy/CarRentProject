using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRent3.Model;
using CarRent3.Dto;

namespace CarRent3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRentdbContext _context;

        public CarController(CarRentdbContext context)
        {
            _context = context;
        }

       // GET: api/Car
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            List<CarDto> cars = new List<CarDto>();

            var result = await _context.Cars.ToListAsync();

            cars = result.Select(x => new CarDto { CarId = x.CarId,
                categoryname = x.Categoryname,
                Model = x.Model,
                Compny = x.Compny,
                Color = x.Color,
                Year = x.Year,
                DailyRentPrice = x.DailyRentPrice,
                Type = x.Type
            }).ToList();

            return cars;
        }




        [HttpGet("Models")]
        public async Task<ActionResult<IEnumerable<CarModelDto>>> GetModel()
        {
            List<CarModelDto> cars = new List<CarModelDto>();

            var result = await _context.Cars.ToListAsync();

            cars = result.Select(x => new CarModelDto
            {
                Model = x.Model
            }).ToList();

            return cars;
        }
        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<CarCategoriesDto>>> GetGategories()
        {
            List<CarCategoriesDto> cars = new List<CarCategoriesDto>();

            var result = await _context.Cars.ToListAsync();

            cars = result.Select(x => new CarCategoriesDto
            {
                categoryname = x.Categoryname
            }).Distinct().ToList();

            return cars;
        }
        // GET: api/Car
        [HttpGet("filter/{catname}/{modelName}/{isAvailability?}")]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCarsByfilter(string? catname, string? modelName, bool? isAvailability)
        {
            List<CarDto> cars = new List<CarDto>();
            List<Car> result;

            if (isAvailability == null)
                result = await _context.Cars.Where(x => catname == null | x.Categoryname == catname &&
                  modelName == null | x.Model == modelName
                ).ToListAsync();
            else
            {
                var availability = (from c in _context.Cars
                                    join inv in _context.Inventories on c.CarId equals inv.CarId
                                    where inv.Availability == isAvailability
                                    select c);

                result = await availability.Where(x => catname == null | x.Categoryname == catname &&
                 modelName == null | x.Model == modelName
               ).ToListAsync();
            }

            cars = result.Select(x => new CarDto
            {
                CarId = x.CarId,
                categoryname = x.Categoryname,
                Model = x.Model,
                Compny = x.Compny,
                Color = x.Color,
                Year = x.Year,
                DailyRentPrice = x.DailyRentPrice,
                Type = x.Type
            }).ToList();

            return cars;
        }


        // GET: api/Car/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Car/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.CarId)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Car
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.CarId }, car);
        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarId == id);
        }
    }
}
