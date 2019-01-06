using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHangServer;
using QuanLyNhaHangServer.Helpers;
using QuanLyNhaHangServer.Models;

namespace QuanLyNhaHangServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCategoriesController : ControllerBase
    {
        private readonly AppContext _context;

        public FoodCategoriesController(AppContext context)
        {
            _context = context;
        }

        // GET: api/FoodCategories
        [HttpGet]
        public IActionResult GetFoodCategories()
        {
            var jObject = Utils.getJObjectResponseFromArray(true, _context.FoodCategories.ToList());
            return Ok(jObject);
        }

        // GET: api/FoodCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodCategory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foodCategory = await _context.FoodCategories.FindAsync(id);

            if (foodCategory == null)
            {
                return NotFound();
            }
            var jObject = Utils.getJObjectResponseFromObject(true, foodCategory);
            return Ok(jObject);
        }

        // PUT: api/FoodCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodCategory([FromRoute] long id, [FromForm] FoodCategory foodCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foodCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(foodCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodCategoryExists(id))
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

        // POST: api/FoodCategories
        [HttpPost]
        public async Task<IActionResult> PostFoodCategory([FromForm] FoodCategory foodCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FoodCategories.Add(foodCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodCategory", new { id = foodCategory.Id }, foodCategory);
        }

        // DELETE: api/FoodCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodCategory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foodCategory = await _context.FoodCategories.FindAsync(id);
            if (foodCategory == null)
            {
                return NotFound();
            }

            _context.FoodCategories.Remove(foodCategory);
            await _context.SaveChangesAsync();

            return Ok(foodCategory);
        }

        private bool FoodCategoryExists(long id)
        {
            return _context.FoodCategories.Any(e => e.Id == id);
        }
    }
}