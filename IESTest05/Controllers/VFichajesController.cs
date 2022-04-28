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

        // In: Token, fecha inicio, fecha fin | Out: Listado de vfichajes correspondientes
        [HttpPost] // POST api/vfichajes
        public IEnumerable<VFichajes> Post(string token, DateTime inicio, DateTime fin)
        {
            try
            {
                var usuario = db.TUsuarios.FirstOrDefault(t => t.Token == token);

                if (usuario == null)
                    return null;

                return db.VFichajes.Where(vf => vf.Fecha >= inicio && vf.Fecha <= fin && vf.Personal == usuario.Personal).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
