using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHangServer;
using QuanLyNhaHangServer.Models;

namespace QuanLyNhaHangServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodWithOrdersController : ControllerBase
    {
        private readonly AppContext _context;

        public FoodWithOrdersController(AppContext context)
        {
            _context = context;
        }

        // GET: api/FoodWithOrders
        [HttpGet]
        public IEnumerable<FoodWithOrder> GetFoodWithOrders()
        {
            return _context.FoodWithOrders;
        }

        // GET: api/FoodWithOrders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodWithOrder([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foodWithOrder = await _context.FoodWithOrders.FindAsync(id);

            if (foodWithOrder == null)
            {
                return NotFound();
            }

            return Ok(foodWithOrder);
        }

        // PUT: api/FoodWithOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodWithOrder([FromRoute] long id, [FromForm] FoodWithOrder foodWithOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foodWithOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(foodWithOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodWithOrderExists(id))
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

        // POST: api/FoodWithOrders
        [HttpPost]
        public async Task<IActionResult> PostFoodWithOrder([FromForm] FoodWithOrder foodWithOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FoodWithOrders.Add(foodWithOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodWithOrder", new { id = foodWithOrder.Id }, foodWithOrder);
        }

        // DELETE: api/FoodWithOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodWithOrder([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foodWithOrder = await _context.FoodWithOrders.FindAsync(id);
            if (foodWithOrder == null)
            {
                return NotFound();
            }

            _context.FoodWithOrders.Remove(foodWithOrder);
            await _context.SaveChangesAsync();

            return Ok(foodWithOrder);
        }

        private bool FoodWithOrderExists(long id)
        {
            return _context.FoodWithOrders.Any(e => e.Id == id);
        }
    }
}