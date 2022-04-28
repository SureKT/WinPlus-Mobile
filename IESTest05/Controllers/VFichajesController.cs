using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IESTest05.Entity;
using IESTest05.Data;
using System.Globalization;
using MobileLite.Entities;

namespace MobileLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VFichajesController : ControllerBase
    {
        private readonly DataContext db;

        public VFichajesController(DataContext context)
        {
            db = context;
        }

        //Recibe conmo parameto de entrada el token de sesion del usuario y la fecha inicio y fin devuelve un listado de fichajes dentro de esas fechas
        [HttpPost] // POST api/vfichajes
        public IEnumerable<VFichajes> Post(string token, DateTime inicio, DateTime fin)
        {
            try
            {
                // Recuperamos los datos de la sesión
                var tUser = db.TUsuarios.FirstOrDefault(t => t.Token == token);

                if (tUser == null)
                    return null;

                //Recuperamos un listado de los fichajes que este usuario realizó en el intervalo indicado

                return db.VFichajes.Where(vf => vf.Fecha >= inicio && vf.Fecha <= fin && vf.Personal == tUser.Personal).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
