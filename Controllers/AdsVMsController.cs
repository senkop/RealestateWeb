using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Try.DAL.Database;
using Try.Models;

namespace Try.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsVMsController : ControllerBase
    {
        private readonly DbContainer _context;

        public AdsVMsController(DbContainer context)
        {
            _context = context;
        }

        // GET: api/AdsVMs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdsVM>>> GetAdsVM()
        {
            return await _context.AdsVM.ToListAsync();
        }

        // GET: api/AdsVMs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdsVM>> GetAdsVM(int id)
        {
            var adsVM = await _context.AdsVM.FindAsync(id);

            if (adsVM == null)
            {
                return NotFound();
            }

            return adsVM;
        }

        // PUT: api/AdsVMs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdsVM(int id, AdsVM adsVM)
        {
            if (id != adsVM.Id)
            {
                return BadRequest();
            }

            _context.Entry(adsVM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdsVMExists(id))
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

        // POST: api/AdsVMs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdsVM>> PostAdsVM(AdsVM adsVM)
        {
            _context.AdsVM.Add(adsVM);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdsVM", new { id = adsVM.Id }, adsVM);
        }

        // DELETE: api/AdsVMs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdsVM(int id)
        {
            var adsVM = await _context.AdsVM.FindAsync(id);
            if (adsVM == null)
            {
                return NotFound();
            }

            _context.AdsVM.Remove(adsVM);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdsVMExists(int id)
        {
            return _context.AdsVM.Any(e => e.Id == id);
        }
    }
}
