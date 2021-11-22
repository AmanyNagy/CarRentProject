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
        private readonly CarRentContext _context;

        public CarController(CarRentContext context)
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
                Category = x.Category,
                Model = x.Model,
                Compny = x.Compny,
                Color = x.Color,
                Year = x.Year,
                DailyRentPrice = x.DailyRentPrice,
                Type = x.Type
            }).ToList();

            return cars;
        }

        public class Filter {

            public int? catId { get; set; }
            public string? modelName { get; set; }
            public bool? isAvailability { get; set; }
        }

        // GET: api/Car
        //[HttpGet("filter/catId={catId}/modelName={modelName}/availabe={isAvailability?}")]
        [HttpGet("/filter")]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCarsByfilter(Filter filter)
        {
            List<CarDto> cars = new List<CarDto>();
            List<Car> result;

            if (filter.isAvailability == null)
            {
                result = await _context.Cars.Where(x => filter.catId == null | x.Category == filter.catId &&
                                                   filter.modelName == null | x.Model == filter.modelName
                                                    ).ToListAsync();
            }
            else
            {
                result = (from c in _context.Cars
                          join inv in _context.Inventories on c.CarId equals inv.CarId
                          where inv.Availability == filter.isAvailability &&
                          filter.catId == null | c.Category == filter.catId &&
                          filter.modelName == null | c.Model == filter.modelName
                          select c).ToList();
            }
         

            cars = result.Select(x => new CarDto
            {
                CarId = x.CarId,
                Category = x.Category,
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
