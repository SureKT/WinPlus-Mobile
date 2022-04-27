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
    public class VContadoresController : ControllerBase
    {
        private readonly DataContext db;

        public VContadoresController(DataContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<object> verVContadoresFechas(String token, DateTime inicio, DateTime fin)
        {
            var tUsuario = db.TUsuarios.FirstOrDefault(u => u.Token == token);

            if (tUsuario == null)
                return null;
                //return BadRequest("Token incorrecto");

            return db.VContadores.Where(vc =>
                vc.Personal == tUsuario.Personal &&
                vc.Fecha >= inicio &&
                vc.Fecha <= fin)
                .GroupBy(vc => vc.Contador)
                .Select(c => new
                {
                    Contador = c.Key,
                    Valor = c.Sum(v => v.Valor)
                })
                .Join(db.Contadores,
                vc => vc.Contador,
                c => c.Codigo,
                (vc, c) => new { Codigo = vc.Contador, Descripcion = c.Descripcion, Valor = vc.Valor, Consultar = c.Consultar }).Where(c => c.Consultar == 1);

            /*
            return context.VContadores
            .Where(vc => vc.Fecha >= fechaini && vc.Fecha <= fechafin && vc.Personal == tUser.Personal)
            .GroupBy(vc => vc.Contador)
            .Select(c => new
            {
            Contador = c.Key,
            Valor = c.Sum(v => v.Valor)
            })
            .Join(context.Contadores,
            vc => vc.Contador,
            c => c.Codigo,
            (vc, c) => new { Codigo = vc.Contador, Descripcion = c.Descripcion, Valor = vc.Valor, Tipo = c.Tipo });
            */
        }
    }
}