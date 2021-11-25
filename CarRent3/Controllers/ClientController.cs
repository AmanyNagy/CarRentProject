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

namespace CarRent3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly CarRentdbContext _context;

        public ClientController(CarRentdbContext context)
        {
            _context = context;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinet>>> GetClinets()
        {
            return await _context.Clinets.ToListAsync();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clinet>> GetClinet(int id)
        {
            var clinet = await _context.Clinets.FindAsync(id);

            if (clinet == null)
            {
                return NotFound();
            }

            return clinet;
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClinet(int id, Clinet clinet)
        {
            if (id != clinet.ClinetId)
            {
                return BadRequest();
            }

            _context.Entry(clinet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinetExists(id))
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

        // POST: api/Client/rigestr
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("rigestr")]
        public async Task<ActionResult<Clinet>> PostClinet(Clinet clinet)
        {

            bool user = _context.Clinets.Any(x => x.UserName == clinet.UserName);
            if (user) { // Exisit
                return StatusCode(StatusCodes.Status500InternalServerError,
                 new Response { Status = "Error", Message = "User already exists!" });
            }

            _context.Clinets.Add(clinet);
            await _context.SaveChangesAsync();

            var newClient = new ClientDto()
            {
                ClinetId = clinet.ClinetId,
                UserName= clinet.UserName,
                Password = clinet.Password,
                Moblie = clinet.Moblie,
                Email = clinet.Email,
                Adress = clinet.Adress

            };


            return CreatedAtAction("GetClinet", new { id = clinet.ClinetId }, newClient);
        }


        // POST: api/Client/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Login")]
        public async Task<ActionResult<Clinet>> LoginClinet(UserLogin clinetLogin)
        {

            bool user = _context.Clinets.Any(x => x.UserName == clinetLogin.UserName);
            if (!user)
            { // Exisit
                return StatusCode(StatusCodes.Status500InternalServerError,
                 new Response { Status = "Error", Message = "User already NOT exists!" });
            }


            bool logincheck = _context.Clinets.Any(x => x.UserName == clinetLogin.UserName & x.Password == clinetLogin.Password);
            if (!logincheck) {

                return StatusCode(StatusCodes.Status500InternalServerError,
                 new Response { Status = "Error", Message = "Username or password not correct" });
            }

            return StatusCode(StatusCodes.Status200OK,
                  new Response { Status = "Scussed", Message = "Welcome" });
        }


        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinet(int id)
        {
            var clinet = await _context.Clinets.FindAsync(id);
            if (clinet == null)
            {
                return NotFound();
            }

            _context.Clinets.Remove(clinet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClinetExists(int id)
        {
            return _context.Clinets.Any(e => e.ClinetId == id);
        }
    }
}
