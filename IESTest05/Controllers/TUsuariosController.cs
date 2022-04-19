using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IESTest05.Data;
using IESTest05.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IESTest05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TUsuariosController : ControllerBase
    {
        private readonly DataContext context;

        public TUsuariosController(DataContext _context)
        {
            context = _context;
        }

        // GET: api/TUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TUsuarios>>> GetTUsuarios()
        {
            return await context.TUsuarios.ToListAsync();
        }

        // GET: api/TUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TUsuarios>> GetTUsuarios(string id)
        {
            var tUsuarios = await context.TUsuarios.FindAsync(id);

            if (tUsuarios == null)
            {
                return NotFound();
            }

            return tUsuarios;
        }

        // PUT: api/TUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTUsuarios(string id, TUsuarios tUsuarios)
        {
            if (id != tUsuarios.Login)
            {
                return BadRequest();
            }

            context.Entry(tUsuarios).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TUsuariosExists(id))
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

        // POST: api/TUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<TUsuarios> LoginTusuarios(TUsuarios usuario)
        {
            if (TUsuariosExists(usuario.Login))
            {
                TUsuarios miUsuario = context.TUsuarios.FirstOrDefault(u => u.Login == usuario.Login);

                if (miUsuario.Password == usuario.Password)
                {
                    String token = Guid.NewGuid().ToString();
                    miUsuario.Token = token;

                    context.SaveChanges();

                    return Ok("Usuario correcto" + " | Token: " + token);
                }
                else
                {
                    return Ok("Contraseña incorrecta");
                }
            }
            else
            {
                return BadRequest("El usuario no existe");
            }
        }

        // DELETE: api/TUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTUsuarios(string id)
        {
            var tUsuarios = await context.TUsuarios.FindAsync(id);
            if (tUsuarios == null)
            {
                return NotFound();
            }

            context.TUsuarios.Remove(tUsuarios);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool TUsuariosExists(string id)
        {
            return context.TUsuarios.Any(e => e.Login == id);
        }
    }
}