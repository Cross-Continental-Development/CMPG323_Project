using CCD_SHARE2TEACH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CCD_SHARE2TEACH.Controllers
{
    [Route("/TAGS")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly TAGSDbContext _tagsContext;

        public TagsController(TAGSDbContext tagsContext)
        {
            _tagsContext = tagsContext;
        }

        // Get : api/TAGS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TAGS>>> GetTags()
        {
            if (_tagsContext.TAGS == null)
            {
                return NotFound();
            }
            return await _tagsContext.TAGS.ToListAsync();
        }


        // Get : api/TAGS/2
        [HttpGet("{id}")]
        public async Task<ActionResult<TAGS>> GetTag(int id)
        {
            if (_tagsContext.TAGS is null)
            {
                return NotFound();
            }
            var tag = await _tagsContext.TAGS.FindAsync(id);
            if (tag is null)
            {
                return NotFound();
            }
            return tag;
        }

        // Post : api/TAGS
        [HttpPost]
        public async Task<ActionResult<TAGS>> PostStudent(TAGS tag)
        {
            _tagsContext.TAGS.Add(tag);
            await _tagsContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTag), new { id = tag.Id }, tag);
        }

        // Put : api/TAGS/2
        [HttpPut]
        public async Task<ActionResult<TAGS>> PutTAGS(int id, TAGS tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }
            _tagsContext.Entry(tag).State = EntityState.Modified;
            try
            {
                await _tagsContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tagExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        private bool tagExists(long id)
        {
            return (_tagsContext.TAGS?.Any(tag => tag.Id == id)).GetValueOrDefault();
        }

        // Delete : api/TAGS/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<TAGS>> Deletetag(int id)
        {
            if (_tagsContext.TAGS is null)
            {
                return NotFound();
            }
            var tag = await _tagsContext.TAGS.FindAsync(id);
            if (tag is null)
            {
                return NotFound();
            }
            _tagsContext.TAGS.Remove(tag);
            await _tagsContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
