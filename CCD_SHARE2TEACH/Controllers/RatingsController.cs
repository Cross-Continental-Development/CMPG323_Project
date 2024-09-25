using CCD_SHARE2TEACH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Controllers
{
    [Route("/RATINGS")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly RatingsDbContext _ratingsContext;

        public RatingsController(RatingsDbContext ratingsContext)
        {
            _ratingsContext = ratingsContext;
        }

        // Get : api/Ratings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RATINGS>>> GetRatings()
        {
            if (_ratingsContext.RATINGS == null)
            {
                return NotFound();
            }
            return await _ratingsContext.RATINGS.ToListAsync();
        }

        // Get : api/Ratings/2
        [HttpGet("{id}")]
        public async Task<ActionResult<RATINGS>> GetRating(int id)
        {
            if (_ratingsContext.RATINGS is null)
            {
                return NotFound();
            }
            var grade = await _ratingsContext.RATINGS.FindAsync(id);
            if (grade is null)
            {
                return NotFound();
            }
            return grade;
        }
        
        // Post : api/Ratings
        [HttpPost]
        public async Task<ActionResult<RATINGS>> PostRating(RATINGS rating)
        {
            _ratingsContext.RATINGS.Add(rating);
            await _ratingsContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRating), new { id = rating.Id }, rating);
        }

        // Put : api/Ratings
        [HttpPut]
        public async Task<ActionResult<RATINGS>> PutRatings(int id, RATINGS rating)
        {
            if (id != rating.Id)
            {
                return BadRequest();
            }
            _ratingsContext.Entry(rating).State = EntityState.Modified;
            try
            {
                await _ratingsContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        private bool RatingExists(long id)
        {
            return (_ratingsContext.RATINGS?.Any(rating => rating.Id == id)).GetValueOrDefault();
        }

        // Delete : api/Ratings
        [HttpDelete("{id}")]
        public async Task<ActionResult<RATINGS>> DeleteRating(int id)
        {
            if (_ratingsContext.RATINGS is null)
            {
                return NotFound();
            }
            var grade = await _ratingsContext.RATINGS.FindAsync(id);
            if (grade is null)
            {
                return NotFound();
            }
            _ratingsContext.RATINGS.Remove(grade);
            await _ratingsContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
