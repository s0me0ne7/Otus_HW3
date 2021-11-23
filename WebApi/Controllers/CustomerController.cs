
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<Customer>> GetCustomerAsync([FromRoute] long id)
        {
             var customer = (await _context.Customers.FindAsync(id));
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] Customer customer)
        {
            if (_context.Customers.AnyAsync(n => customer.Firstname == n.Firstname && customer.Lastname == n.Lastname).Result)
            {
                return Conflict();
            }
            await this._context.AddAsync(customer);
            await this._context.SaveChangesAsync();

            return Ok(customer.Id);
        }
    }
}