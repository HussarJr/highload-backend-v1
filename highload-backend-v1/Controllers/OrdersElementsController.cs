using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using highload_backend_v1;

namespace highload_backend_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersElementsController : ControllerBase
    {
        private readonly PrContext _context;

        public OrdersElementsController(PrContext context)
        {
            _context = context;
        }

        // GET: api/OrdersElements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersElement>>> GetOrdersElements()
        {
          if (_context.OrdersElements == null)
          {
              return NotFound();
          }
            return await _context.OrdersElements.ToListAsync();
        }

        // GET: api/OrdersElements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersElement>> GetOrdersElement(string id)
        {
          if (_context.OrdersElements == null)
          {
              return NotFound();
          }
            var ordersElement = await _context.OrdersElements.FindAsync(id);

            if (ordersElement == null)
            {
                return NotFound();
            }

            return ordersElement;
        }

        // PUT: api/OrdersElements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersElement(string id, OrdersElement ordersElement)
        {
            if (id != ordersElement.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordersElement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersElementExists(id))
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

        // POST: api/OrdersElements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdersElement>> PostOrdersElement(OrdersElement ordersElement)
        {
          if (_context.OrdersElements == null)
          {
              return Problem("Entity set 'PrContext.OrdersElements'  is null.");
          }
            _context.OrdersElements.Add(ordersElement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrdersElementExists(ordersElement.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrdersElement", new { id = ordersElement.Id }, ordersElement);
        }

        // DELETE: api/OrdersElements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdersElement(string id)
        {
            if (_context.OrdersElements == null)
            {
                return NotFound();
            }
            var ordersElement = await _context.OrdersElements.FindAsync(id);
            if (ordersElement == null)
            {
                return NotFound();
            }

            _context.OrdersElements.Remove(ordersElement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdersElementExists(string id)
        {
            return (_context.OrdersElements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
