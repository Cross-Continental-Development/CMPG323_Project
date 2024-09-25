using CCD_SHARE2TEACH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Controllers
{
    [Route("/MODERATIONS")]
    [ApiController]
    public class ModerationsController : ControllerBase
    {
        private readonly ModerationsDBContext _moderationsContext;

        public ModerationsController(ModerationsDBContext moderationsContext)
        {
            _moderationsContext = moderationsContext;
        }

        // Get : api/MODERATIONS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MODERATIONS>>> GetMODERATIONS()
        {
            if (_moderationsContext.MODERATIONS == null)
            {
                return NotFound();
            }
            return await _moderationsContext.MODERATIONS.ToListAsync();
        }

        // Get : api/MODERATIONS/2
        [HttpGet("{id}")]
        public async Task<ActionResult<MODERATIONS>> GetMODERATION(int id)
        {
            if (_moderationsContext.MODERATIONS is null)
            {
                return NotFound();
            }
            var modvar = await _moderationsContext.MODERATIONS.FindAsync(id);
            if (modvar is null)
            {
                return NotFound();
            }
            return modvar;
        }

        // Post : api/MODERATIONS
        [HttpPost]
        public async Task<ActionResult<MODERATIONS>> PostMODERATIONS(MODERATIONS mod)
        {
            _moderationsContext.MODERATIONS.Add(mod);
            await _moderationsContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMODERATION), new { id = mod.Id }, mod);
        }

        // Put : api/MODERATIONS/2
        [HttpPut]
        public async Task<ActionResult<MODERATIONS>> PutMODERATIONS(int id, MODERATIONS mod)
        {
            if (id != mod.Id)
            {
                return BadRequest();
            }
            _moderationsContext.Entry(mod).State = EntityState.Modified;
            try
            {
                await _moderationsContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MODERATIONSExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        private bool MODERATIONSExists(long id)
        {
            return (_moderationsContext.MODERATIONS?.Any(mod => mod.Id == id)).GetValueOrDefault();
        }

        // Delete : api/MODERATIONS
        [HttpDelete("{id}")]
        public async Task<ActionResult<MODERATIONS>> DeleteMODERATIONS(int id)
        {
            if (_moderationsContext.MODERATIONS is null)
            {
                return NotFound();
            }
            var docvar = await _moderationsContext.MODERATIONS.FindAsync(id);
            if (docvar is null)
            {
                return NotFound();
            }
            _moderationsContext.MODERATIONS.Remove(docvar);
            await _moderationsContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
