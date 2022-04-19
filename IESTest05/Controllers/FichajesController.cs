using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IESTest05.Entity;
using IESTest05.Data;

namespace IESTest05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichajesController : ControllerBase
    {
        private readonly DataContext context;

        public FichajesController(DataContext _context)
        {
            context = _context;
        }

        // GET: api/Fichajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fichajes>>> GetFichajes()
        {
            return await context.Fichajes.ToListAsync();
        }

        // GET: api/Fichajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fichajes>> GetFichaje(DateTime id)
        {
            var fichaje = await context.Fichajes.FindAsync(id);

            if (fichaje == null)
            {
                return NotFound();
            }

            return fichaje;
        }

        // PUT: api/Fichajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFichaje(DateTime id, Fichajes fichaje)
        {
            if (id != fichaje.Hora)
            {
                return BadRequest();
            }

            context.Entry(fichaje).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FichajeExists(id))
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

        // POST: api/Fichajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fichajes>> PostFichaje(Fichajes fichaje)
        {
            context.Fichajes.Add(fichaje);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FichajeExists(fichaje.Hora))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFichaje", new { id = fichaje.Hora }, fichaje);
        }

        // DELETE: api/Fichajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFichaje(DateTime id)
        {
            var fichaje = await context.Fichajes.FindAsync(id);
            if (fichaje == null)
            {
                return NotFound();
            }

            context.Fichajes.Remove(fichaje);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool FichajeExists(DateTime id)
        {
            return context.Fichajes.Any(e => e.Hora == id);
        }
    }
}
