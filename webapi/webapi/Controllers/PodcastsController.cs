using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi;
using webapi.Data;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PodcastsController : ControllerBase
    {
        private readonly PodcastContext _context;

        public PodcastsController(PodcastContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Podcast>>> GetPodcasts()
        {
            return await _context.Podcasts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Podcast>> GetPodcast(int id)
        {
            var podcast = await _context.Podcasts.FindAsync(id);

            if (podcast == null)
            {
                return NotFound();
            }

            return podcast;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPodcast(int id, Podcast podcast)
        {
            if (id != podcast.Id)
            {
                return BadRequest();
            }

            _context.Entry(podcast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PodcastExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Podcast>> PostPodcast(Podcast podcast)
        {
            _context.Podcasts.Add(podcast);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPodcast", new { id = podcast.Id }, podcast);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePodcast(int id)
        {
            var podcast = await _context.Podcasts.FindAsync(id);
            if (podcast == null)
            {
                return NotFound();
            }

            _context.Podcasts.Remove(podcast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PodcastExists(int id)
        {
            return _context.Podcasts.Any(e => e.Id == id);
        }
    }
}
