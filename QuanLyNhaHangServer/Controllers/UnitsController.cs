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
    public class UnitsController : ControllerBase
    {
        private readonly AppContext _context;

        public UnitsController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Units
        [HttpGet]
        public IActionResult GetUnits()
        {
            var jObject = Utils.getJObjectResponseFromArray(true, _context.Units.ToList());
            return Ok(jObject);
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnit([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unit = await _context.Units.FindAsync(id);

            if (unit == null)
            {
                return NotFound();
            }

            var jObject = Utils.getJObjectResponseFromObject(true, unit);
            return Ok(unit);
        }

        // PUT: api/Units/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnit([FromRoute] long id, [FromForm] Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unit.Id)
            {
                return BadRequest();
            }

            _context.Entry(unit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(id))
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

        // POST: api/Units
        [HttpPost]
        public async Task<IActionResult> PostUnit([FromForm] Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Units.Add(unit);
            await _context.SaveChangesAsync();
            var jObject = Utils.getJObjectResponseFromObject(true, unit);
            return CreatedAtAction("GetUnit", new { id = unit.Id }, jObject);
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unit = await _context.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();

            return Ok(unit);
        }

        private bool UnitExists(long id)
        {
            return _context.Units.Any(e => e.Id == id);
        }
    }
}