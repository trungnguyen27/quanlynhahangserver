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
    public class TablesController : ControllerBase
    {
        private readonly AppContext _context;

        public TablesController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Tables
        [HttpGet]
        public IActionResult GetTables()
        {
            var jObject = Utils.getJObjectResponseFromArray(true, _context.Tables.ToList());
            return Ok(jObject);
        }

        // GET: api/Tables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTable([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var table = await _context.Tables.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }
            var jObject = Utils.getJObjectResponseFromObject(true, table);
            return Ok(jObject);
        }

        // PUT: api/Tables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable([FromRoute] long id, [FromForm] Table table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != table.Id)
            {
                return BadRequest();
            }

            _context.Entry(table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(id))
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

        // POST: api/Tables
        [HttpPost]
        public async Task<IActionResult> PostTable([FromForm] Table table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var found = TableExists(table.TableId);
            if (found)
            {
                return Ok(Utils.getJObjectResponseFromObject(false, table));
            }

            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            var jObject = Utils.getJObjectResponseFromObject(true, table);
            return CreatedAtAction("GetTable", new { id = table.Id }, jObject);
        }

        // DELETE: api/Tables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return Ok(table);
        }

        private bool TableExists(long id)
        {
            return _context.Tables.Any(e => e.TableId == id);
        }
    }
}