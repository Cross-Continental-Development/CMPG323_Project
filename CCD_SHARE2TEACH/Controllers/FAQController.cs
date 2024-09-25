using CCD_SHARE2TEACH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Controllers
{
    [Route("/FAQ")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly FAQDBContext _faqContext;

        public FAQController(FAQDBContext faqContext)
        {
            _faqContext = faqContext;
        }

        // Get : api/FAQ
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FAQ>>> GetFAQs()
        {
            if (_faqContext.FAQ == null)
            {
                return NotFound();
            }
            return await _faqContext.FAQ.ToListAsync();
        }

        // Get : api/FAQ/2
        [HttpGet("{id}")]
        public async Task<ActionResult<FAQ>> GetFAQ(int id)
        {
            if (_faqContext.FAQ is null)
            {
                return NotFound();
            }
            var faqvar = await _faqContext.FAQ.FindAsync(id);
            if (faqvar is null)
            {
                return NotFound();
            }
            return faqvar;
        }

        // Post : api/FAQ
        [HttpPost]
        public async Task<ActionResult<FAQ>> PostFAQ(FAQ qa)
        {
            _faqContext.FAQ.Add(qa);
            await _faqContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFAQ), new { id = qa.Id }, qa);
        }

        // Put : api/FAQ/2
        [HttpPut]
        public async Task<ActionResult<FAQ>> PutFAQ(int id, FAQ qa)
        {
            if (id != qa.Id)
            {
                return BadRequest();
            }
            _faqContext.Entry(qa).State = EntityState.Modified;
            try
            {
                await _faqContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FAQExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        private bool FAQExists(long id)
        {
            return (_faqContext.FAQ?.Any(qa => qa.Id == id)).GetValueOrDefault();
        }

        // Delete : api/FAQ
        [HttpDelete("{id}")]
        public async Task<ActionResult<FAQ>> DeleteFAQ(int id)
        {
            if (_faqContext.FAQ is null)
            {
                return NotFound();
            }
            var docvar = await _faqContext.FAQ.FindAsync(id);
            if (docvar is null)
            {
                return NotFound();
            }
            _faqContext.FAQ.Remove(docvar);
            await _faqContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
