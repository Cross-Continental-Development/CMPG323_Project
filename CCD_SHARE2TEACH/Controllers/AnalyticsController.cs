using CCD_SHARE2TEACH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCD_SHARE2TEACH.Controllers
{
    [Route("/ANALYTICS")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly AnalyticsDBContext _analyticsContext;

        public AnalyticsController(AnalyticsDBContext analyticsContext)
        {
            _analyticsContext = analyticsContext;
        }

        // Get : api/Analytics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ANALYTICS>>> GetAnalytics()
        {
            if (_analyticsContext.ANALYTICS == null)
            {
                return NotFound();
            }
            return await _analyticsContext.ANALYTICS.ToListAsync();
        }

        // Get : api/Analytics/2
        [HttpGet("{id}")]
        public async Task<ActionResult<ANALYTICS>> GetAnalyticsMetric(int id)
        {
            if (_analyticsContext.ANALYTICS is null)
            {
                return NotFound();
            }
            var docvar = await _analyticsContext.ANALYTICS.FindAsync(id);
            if (docvar is null)
            {
                return NotFound();
            }
            return docvar;
        }

        // Post : api/Analytics
        [HttpPost]
        public async Task<ActionResult<ANALYTICS>> PostAnalyticsMetric(ANALYTICS metric)
        {
            _analyticsContext.ANALYTICS.Add(metric);
            await _analyticsContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAnalyticsMetric), new { id = metric.Id }, metric);
        }
    }
}
