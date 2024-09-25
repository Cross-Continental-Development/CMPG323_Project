using CCD_SHARE2TEACH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Controllers
{
    [Route("/DOCUMENTS")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentsDbContext _documentsContext;

        public DocumentsController(DocumentsDbContext documentsContext)
        {
            _documentsContext = documentsContext;
        }

        // Get : api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DOCUMENTS>>> GetDocuments()
        {
            if (_documentsContext.DOCUMENTS == null)
            {
                return NotFound();
            }
            return await _documentsContext.DOCUMENTS.ToListAsync();
        }

        // Get : api/Documents/2
        [HttpGet("{id}")]
        public async Task<ActionResult<DOCUMENTS>> GetDocument(int id)
        {
            if (_documentsContext.DOCUMENTS is null)
            {
                return NotFound();
            }
            var docvar = await _documentsContext.DOCUMENTS.FindAsync(id);
            if (docvar is null)
            {
                return NotFound();
            }
            return docvar;
        }

        // Post : api/Documents
        [HttpPost]
        public async Task<ActionResult<DOCUMENTS>> PostDocument(DOCUMENTS docs)
        {
            _documentsContext.DOCUMENTS.Add(docs);
            await _documentsContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDocument), new { id = docs.Id }, docs);
        }

        // Put : api/Documents/2
        [HttpPut]
        public async Task<ActionResult<DOCUMENTS>> PutDocument(int id, DOCUMENTS docs)
        {
            if (id != docs.Id)
            {
                return BadRequest();
            }
            _documentsContext.Entry(docs).State = EntityState.Modified;
            try
            {
                await _documentsContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        private bool DocumentExists(long id)
        {
            return (_documentsContext.DOCUMENTS?.Any(docs => docs.Id == id)).GetValueOrDefault();
        }

        // Delete : api/Document
        [HttpDelete("{id}")]
        public async Task<ActionResult<DOCUMENTS>> DeleteDocument(int id)
        {
            if (_documentsContext.DOCUMENTS is null)
            {
                return NotFound();
            }
            var docvar = await _documentsContext.DOCUMENTS.FindAsync(id);
            if (docvar is null)
            {
                return NotFound();
            }
            _documentsContext.DOCUMENTS.Remove(docvar);
            await _documentsContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
