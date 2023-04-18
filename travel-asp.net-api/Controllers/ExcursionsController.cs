using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using travel_asp.net_api.Models;
using travel_asp.net_api.ViewModels;

namespace travel_asp.net_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcursionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
       
        public ExcursionsController(ApplicationDbContext context)
        {
            _context = context;
        
        }
       
        [EnableCors("MyPolicy")]
        // GET: api/Excursions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Excursion>>> GetExcursions()
        {
           
            if (_context.Excursions == null)
            {
                return NotFound();
            }
            return await _context.Excursions.Include(x => x.Images).ToListAsync();
        }
        [EnableCors("MyPolicy")]
        // GET: api/Excursions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Excursion>> GetExcursion(int id)
        {

            if (_context.Excursions == null)
            {
                return NotFound();
            }

            var excursion = await _context.Excursions.Include(x => x.Images).FirstAsync(x => x.Id == id);

            if (excursion == null)
            {
                return NotFound();
            }

            return excursion;
        }
        [EnableCors("MyPolicy")]
        [Authorize(Roles = "Admin")]
        // PUT: api/Excursions/id      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExcursion(int id, Excursion excursion)
        {
            excursion.Id = id;

            _context.Entry(excursion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExcursionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Created($"api/excurions/{id}", excursion);
        }
        private bool ExcursionExists(int id)
        {
            return (_context.Excursions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [EnableCors("MyPolicy")]
        [Authorize(Roles = "Admin")]
        // POST: api/Excursions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Excursion>> PostExcursion(Excursion excursion)
        {
            if (_context.Excursions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Excursions'  is null.");
            }
            _context.Excursions.Add(excursion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExcursion", new { id = excursion.Id }, excursion);
        }
        [EnableCors("MyPolicy")]
        [Authorize(Roles = "Admin")]
        // DELETE: api/Excursions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExcursion(int id)
        {
            if (_context.Excursions == null)
            {
                return NotFound();
            }
            var excursion = await _context.Excursions.FindAsync(id);
            if (excursion == null)
            {
                return NotFound();
            }

            _context.Excursions.Remove(excursion);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
