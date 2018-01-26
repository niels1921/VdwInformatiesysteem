using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managementsysteem.Data;
using Managementsysteem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Managementsysteem.Controllers
{
    [Authorize]

    [Produces("application/json")]
    [Route("api/afspraken")]
    public class AfsprakenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AfsprakenController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Afspraak> GetEvents([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            return from e in _context.Afspraak where !((e.End <= start) || (e.Start >= end)) select e;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.Id == id);

            if (afspraak == null)
            {
                return NotFound();
            }

            return Ok(afspraak);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] Afspraak afspraak)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != afspraak.Id)
            {
                return BadRequest();
            }

            _context.Entry(afspraak).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // PUT: api/Events/5/move
        [HttpPut("{id}/move")]
        public async Task<IActionResult> MoveAfspraak([FromRoute] int id, [FromBody] AfspraakMoveParams param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.Id == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            afspraak.Start = param.Start;
            afspraak.End = param.End;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // PUT: api/Events/5/color
        [HttpPut("{id}/color")]
        public async Task<IActionResult> SetEventColor([FromRoute] int id, [FromBody] AfspraakColorParams param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.Id == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            afspraak.Color = param.Color;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] Afspraak afspraak)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Afspraak.Add(afspraak);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = afspraak.Id }, afspraak);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.Id == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            _context.Afspraak.Remove(afspraak);
            await _context.SaveChangesAsync();

            return Ok(afspraak);
        }

        private bool EventExists(int id)
        {
            return _context.Afspraak.Any(e => e.Id == id);
        }
    }


    public class AfspraakMoveParams
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class AfspraakColorParams
    {
        public string Color { get; set; }
    }

}