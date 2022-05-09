using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WinPlusMobile.Data;
using MobileLite.Entities;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace WinPlusMobile.Controllers
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

        // In: Token, fichaje | Out: Objeto Respuesta | Realiza una insercion de fichaje
        [HttpPost("{token}")] // POST: api/Fichajes
        public Resp Post(String token, [FromBody] Fichajes fichaje)
        {
            try
            {
                // Variables de dia y hora
                DateTime today = DateTime.ParseExact(DateTime.Today.ToString("yyyyMMdd HH:mm"), "yyyyMMdd HH:mm", CultureInfo.InvariantCulture);

                DateTime now = DateTime.ParseExact(DateTime.Now.ToString("yyyyMMdd HH:mm"), "yyyyMMdd HH:mm", CultureInfo.InvariantCulture);

                fichaje.Hora = now;

                // Sesión no encontrada
                var usuario = db.TUsuarios.FirstOrDefault(u => u.Token == token);
                if (usuario == null)
                    return new Resp(1, "Sesión no encontrada");

                // Tarjeta no encontrada
                var personal = db.Personal.FirstOrDefault(p => p.Codigo == usuario.Personal);
                if (personal == null || personal.Tarjeta == null)
                    return new Resp(2, "Tarjeta no encontrada");

                // Ficha de validación no creada
                if (!db.Validacion.Any(v => v.Personal == usuario.Personal && v.Fecha == today))
                    return new Resp(3, "Ficha de validación no creada");

                // Fichaje duplicado
                if (db.Fichajes.Any(f => f.Personal == usuario.Personal && f.Hora == fichaje.Hora))
                    return new Resp(4, "Fichaje duplicado");

                // Fecha de ingreso posterior al fichaje
                if (personal.FechaIngreso > today)
                    return new Resp(5, "Fecha de ingreso posterior al fichaje");

                // Fecha de baja anterior al fichaje
                if (personal.FechaBaja < today)
                    return new Resp(6, "Fecha baja anterior al fichaje");

                // Montamos el insert para VFichajes del fichaje actual
                VFichajes vFichajeInsert = new VFichajes(personal.Codigo, today, now, fichaje.Funcion, fichaje.Causa, "", 0, 0);

                // Añadimos el vfichaje
                db.VFichajes.Add(vFichajeInsert);

                // Modificamos el personal
                personal.UltimoFichaje = now;
                personal.UltimaFuncion = fichaje.Funcion;
                personal.UltimaFicha = today;

                db.Entry(personal).State = EntityState.Modified;

                // Creamos e insertamos en fichaje real
                Fichajes fichajeInsert = new Fichajes(personal.Codigo, now, 23, fichaje.Funcion, personal.Tarjeta, fichaje.Causa, 3, "", 0, 0, fichaje.Longitud, fichaje.Latitud, 0, 0, null);

                // Añadimos el fichaje
                db.Fichajes.Add(fichajeInsert);

                db.SaveChanges();

                // Notificamos el fichaje 
                if (fichaje.Funcion == 1)
                    // Fichaje correcto entrada
                    return new Resp(0, "Fichada entrada a las: " + now.ToString("HH:mm"));

                if (fichaje.Funcion == 2)
                    if (fichaje.Causa == 0) // Fichaje correcto salida
                    {
                        return new Resp(0, "Fichada salida a las: " + now.ToString("HH:mm"));
                    }
                    else if (fichaje.Causa != 0) // Fichaje correcto salida con incidencia
                    {
                        return new Resp(0, "Fichada salida por '" + db.Causas.FirstOrDefault(c => c.Codigo == fichaje.Causa).Descripcion.ToString() + "' a las: " + now.ToString("HH:mm"));
                    }

                return new Resp();
            }
            catch
            {
                return new Resp(-1, "Error al realizar el fichaje");
            }
        }
    }
}
