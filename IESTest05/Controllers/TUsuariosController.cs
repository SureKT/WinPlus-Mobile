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
        private readonly DataContext db;

        public TUsuariosController(DataContext context)
        {
            db = context;
        }

        // GET: api/TUsuarios
        [HttpGet]
        public ActionResult<IEnumerable<TUsuarios>> GetTUsuarios()
        {
            return db.TUsuarios.ToList();
        }

        // GET: api/TUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TUsuarios>> GetTUsuarios(string id)
        {
            var tUsuarios = await db.TUsuarios.FindAsync(id);

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

            db.Entry(tUsuarios).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
                TUsuarios miUsuario = db.TUsuarios.FirstOrDefault(u => u.Login == usuario.Login);

                if (miUsuario.Password == usuario.Password)
                {
                    String token = Guid.NewGuid().ToString();
                    miUsuario.Token = token;

                    db.SaveChanges();

                    return Ok("Usuario correcto" + " | Token: " + token);
                }
                else
                {
                    return BadRequest("Contraseña incorrecta");
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
            var tUsuarios = await db.TUsuarios.FindAsync(id);
            if (tUsuarios == null)
            {
                return NotFound();
            }

            db.TUsuarios.Remove(tUsuarios);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool TUsuariosExists(string id)
        {
            return db.TUsuarios.Any(e => e.Login == id);
        }
    }
}