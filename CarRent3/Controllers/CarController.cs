using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRent3.Model;
using CarRent3.Dto;
using CarRent3.Repositories;
using AutoMapper;

namespace CarRent3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
       private readonly CarRentdbContext _context;
        private readonly ICarRentRepo _carRentRepo;
        private readonly IMapper _mapper;


        public CarController(CarRentdbContext context, ICarRentRepo carRentRepo,
            IMapper mapper)
        {
           _context = context;
            _carRentRepo = carRentRepo ??
                throw new ArgumentNullException(nameof(carRentRepo));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

       // GET: api/Car
        [HttpGet]
        public ActionResult<IEnumerable<CarDto>> GetCars(string catname, string modelName, bool? isAvailability)
        { 

            var carsFromRepo = _carRentRepo.GetCars(catname, modelName, isAvailability);
            return Ok(_mapper.Map<IEnumerable<CarDto>>(carsFromRepo));

        }

        [HttpGet("Models")]
        public ActionResult<IEnumerable<CarModelDto>> GetModel()
        {
            var CarModelsFromRepo = _carRentRepo.GetModel();
            return Ok(_mapper.Map<IEnumerable<CarModelDto>>(CarModelsFromRepo));

        }

        [HttpGet("Categories")]
        public ActionResult<IEnumerable<CarCategoriesDto>> GetGategories()
        {
            var CarCategoriesFromRepo = _carRentRepo.GetCategories();
            return Ok(_mapper.Map<IEnumerable<CarCategoriesDto>>(CarCategoriesFromRepo));
        }

        /*
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
        }*/
    }
}
