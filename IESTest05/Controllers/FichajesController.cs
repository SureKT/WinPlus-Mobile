using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IESTest05.Entity;
using IESTest05.Data;

namespace IESTest05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichajesController : ControllerBase
    {
        private readonly DataContext db;

        public FichajesController(DataContext context)
        {
            db = context;
        }

        // GET: api/Fichajes
        [HttpGet]
        public ActionResult<IEnumerable<Fichajes>> verFichajesFechas(String token, DateTime inicio, DateTime fin)
        {
            var tUsuario = db.TUsuarios.FirstOrDefault(u => u.Token == token);

            if (tUsuario == null)
                return BadRequest("Token incorrecto");

            var fichajes = db.Fichajes.Where(f => f.Personal == tUsuario.Personal && f.Hora >= inicio && f.Hora <= fin).ToList();

            if (fichajes == null)
            {
                return NotFound();
            }

            return fichajes;
        }

        // POST: api/Fichajes
        [HttpPost]
        public ActionResult<Fichajes> InsertarFichaje(String token, Fichajes fichaje)
        {
            DateTime nowTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 00);
            fichaje.Hora = nowTime;

            var tUsuario = db.TUsuarios.FirstOrDefault(u => u.Token == token);
            if (tUsuario == null)
                return BadRequest("Token incorrecto");

            var personal = db.Personal.FirstOrDefault(p => p.Codigo == tUsuario.Personal);
            if (personal.Tarjeta == null)
                return BadRequest("Código 1 - Tarjeta no encontrada");

            var validacion = db.Validacion.FirstOrDefault(v => v.Personal == tUsuario.Personal && v.Fecha == DateTime.Today);
            if (validacion == null)
                return BadRequest("Código 2 - Ficha de validación inexistente");

            var fichajeDuplicado = db.Fichajes.FirstOrDefault(f => f.Personal == tUsuario.Personal && f.Hora == fichaje.Hora);
            if (fichajeDuplicado != null)
                return BadRequest("Código 3 - Fichaje duplicado");

            if (personal.FechaIngreso > fichaje.Hora)
                return BadRequest("Código 4 - Fecha ingreso posterior al fichaje");

            if (personal.FechaBaja < fichaje.Hora)
                return BadRequest("Código 5 - Fecha baja anterior al fichaje");

            db.Fichajes.Add(fichaje);

            db.SaveChanges();

            return Ok("Código 0 - Fichaje correcto");
        }

        private bool FichajeExists(DateTime id, String tarjeta, int estado)
        {
            return db.Fichajes.Any(f => f.Hora == id && f.Tarjeta == tarjeta && f.Estado == estado);
        }
    }
}
