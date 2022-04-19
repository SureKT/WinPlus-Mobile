using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IESTest05.Entity;
using IESTest05.Data;
using System.Globalization;

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

        // GET: api/Fichajes/5
        [HttpGet]
        public ActionResult<IEnumerable<Fichajes>> VerFichajesFechas(String token, DateTime inicio, DateTime fin)
        {
            var tUsuario = context.TUsuarios.FirstOrDefault(u => u.Token == token);

            if (tUsuario == null)
                return BadRequest("Token incorrecto");

            var fichajes = context.Fichajes.Where(f => f.Personal == tUsuario.Personal && f.Hora >= inicio && f.Hora <= fin).ToList();

            if (fichajes == null)
            {
                return NotFound();
            }

            return fichajes;
        }

        // POST: api/Fichajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Fichajes> InsertarFichaje(Fichajes fichaje, String token)
        {
            DateTime nowTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 00);
            fichaje.Hora = nowTime;

            var tUsuario = context.TUsuarios.FirstOrDefault(u => u.Token == token);
            if (tUsuario == null)
                return BadRequest("Token incorrecto");

            var personal = context.Personal.FirstOrDefault(p => p.Codigo == tUsuario.Personal);
            if (personal.Tarjeta == null)
                return BadRequest("Código 1 - Tarjeta no encontrada");

            var validacion = context.Validacion.FirstOrDefault(v => v.Personal == tUsuario.Personal && v.Fecha == DateTime.Today);
            if (validacion == null)
                return BadRequest("Código 2 - Ficha de validación inexistente");

            var fichajeDuplicado = context.Fichajes.FirstOrDefault(f => f.Personal == tUsuario.Personal && f.Hora == fichaje.Hora);
            if (fichajeDuplicado != null)
                return BadRequest("Código 3 - Fichaje duplicado");

            if (personal.FechaIngreso > fichaje.Hora)
                return BadRequest("Código 4 - Fecha ingreso posterior al fichaje");

            if (personal.FechaBaja < fichaje.Hora)
                return BadRequest("Código 5 - Fecha baja anterior al fichaje");

            context.Fichajes.Add(fichaje);

            context.SaveChanges();

            return Ok("Código 0 - Fichaje correcto");
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
