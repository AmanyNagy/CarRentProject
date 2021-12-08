using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRent3.Model;
using CarRent3.Dto;
using JWTAuthentication.Authentication;
using CarRent3.Repositories;
using AutoMapper;

namespace CarRent3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly CarRentdbContext _context;
        private readonly ICarRentRepo _carRentRepo;
        private readonly IMapper _mapper;


        public OrderController(CarRentdbContext context, ICarRentRepo carRentRepo,
            IMapper mapper)
        {
            _context = context;
            _carRentRepo = carRentRepo ??
                throw new ArgumentNullException(nameof(carRentRepo));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Order
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetOrders()
        {
            var OrdersFromRepo = _carRentRepo.GetOrders();
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(OrdersFromRepo));
        }
        
        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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



        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrder(Order order)
        {

            // Date Validtion 

            var Date = _context.Inventories.Select(x => x.AvalibleDate).FirstOrDefault();
            if (order.FromDate < Date | order.FromDate < DateTime.Now | order.ToDate < order.FromDate)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status = "Error", Message = "Can not book at this Date choose another." });
            }


            _context.Orders.Add(order);
            await _context.SaveChangesAsync();


            var neworder = new OrderDto()
            {
                CarId = order.CarId,
                Statue = order.Statue,
                PaymentId = order.PaymentId,
                FromDate = order.FromDate,
                ToDate = order.ToDate,
                OrderSubmitDate = order.OrderSubmitDate,
                CityId  = order.CityId,
                DestinationAddress = order.DestinationAddress,
                ClientId = order.ClientId
            }; 


            return CreatedAtAction("GetOrder", new { id = order.OrderId }, neworder);
        }






        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
