using CCD_SHARE2TEACH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Controllers
{
    [Route("/GRADE")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly GradeDbContext _gradeContext;

        public GradeController(GradeDbContext gradeContext)
        {
            _gradeContext = gradeContext;
        }

        // Get : api/TAGS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GRADE>>> GetGrades()
        {
            if (_gradeContext.GRADE == null)
            {
                return NotFound();
            }
            return await _gradeContext.GRADE.ToListAsync();
        }


        // Get : api/GRADE/2
        [HttpGet("{id}")]
        public async Task<ActionResult<GRADE>> GetGrade(int id)
        {
            if (_gradeContext.GRADE is null)
            {
                return NotFound();
            }
            var grade = await _gradeContext.GRADE.FindAsync(id);
            if (grade is null)
            {
                return NotFound();
            }
            return grade;
        }

        // Post : api/GRADE
        [HttpPost]
        public async Task<ActionResult<GRADE>> PostGrade(GRADE grade)
        {
            _gradeContext.GRADE.Add(grade);
            await _gradeContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGrade), new { id = grade.Id }, grade);
        }

        // Put : api/GRADE/2
        [HttpPut]
        public async Task<ActionResult<GRADE>> PutGRADE(int id, GRADE grade)
        {
            if (id != grade.Id)
            {
                return BadRequest();
            }
            _gradeContext.Entry(grade).State = EntityState.Modified;
            try
            {
                await _gradeContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        private bool GradeExists(long id)
        {
            return (_gradeContext.GRADE?.Any(grade => grade.Id == id)).GetValueOrDefault();
        }

        // Delete : api/GRADE/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<GRADE>> DeleteGrade(int id)
        {
            if (_gradeContext.GRADE is null)
            {
                return NotFound();
            }
            var grade = await _gradeContext.GRADE.FindAsync(id);
            if (grade is null)
            {
                return NotFound();
            }
            _gradeContext.GRADE.Remove(grade);
            await _gradeContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
