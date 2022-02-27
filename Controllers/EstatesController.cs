using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Try.DAL.Database;
using Try.DAL.Entity;

namespace Try.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatesController : ControllerBase
    {
        private readonly DbContainer _context;

        public EstatesController(DbContainer context)
        {
            _context = context;
        }

        // GET: api/Estates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estate>>> GetState()
        {
            return await _context.State.ToListAsync();
        }

        // GET: api/Estates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estate>> GetEstate(int id)
        {
            var estate = await _context.State.FindAsync(id);

            if (estate == null)
            {
                return NotFound();
            }

            return estate;
        }

        // PUT: api/Estates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstate(int id, Estate estate)
        {
            if (id != estate.Id)
            {
                return BadRequest();
            }

            _context.Entry(estate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstateExists(id))
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

        // POST: api/Estates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estate>> PostEstate(Estate estate)
        {
            _context.State.Add(estate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstate", new { id = estate.Id }, estate);
        }

        // DELETE: api/Estates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstate(int id)
        {
            var estate = await _context.State.FindAsync(id);
            if (estate == null)
            {
                return NotFound();
            }

            _context.State.Remove(estate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstateExists(int id)
        {
            return _context.State.Any(e => e.Id == id);
        }
    }
}
