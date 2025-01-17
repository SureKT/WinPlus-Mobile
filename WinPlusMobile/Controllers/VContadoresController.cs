﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WinPlusMobile.Data;

namespace WinPlusMobile.Controllers
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

        // In: Token, fecha inicio, fecha fin | Out: Listado de vcontadores correspondientes
        [HttpPost] // POST api/vcontadores
        public IEnumerable<Object> Post([FromForm] String token, [FromForm] DateTime inicio, [FromForm] DateTime fin)
        {
            try
            {
                var usuario = db.TUsuarios.FirstOrDefault(u => u.Token == token);

                if (usuario == null)
                    return null;

                return db.VContadores.Where(vc =>
                    vc.Personal == usuario.Personal &&
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
                    (vc, c) => new { Codigo = vc.Contador, Descripcion = c.Descripcion, Valor = vc.Valor, Consultar = c.Consultar, Tipo = c.Tipo }).Where(c => c.Consultar == 1);
            }
            catch
            {
                return null;
            }
        }
    }
}