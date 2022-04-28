using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IESTest05.Data;
using MobileLite.Entities;
using IESTest05.Entity;

namespace IESTest05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CausasController : ControllerBase
    {
        private readonly DataContext db;

        public CausasController(DataContext context)
        {
            db = context;
        }

        // GET: api/<CausasController>
        // Devuelve un listado con todas las causas
        [HttpGet]
        public IEnumerable<Causas> Get()
        {
            try
            {
                return db.Causas.ToList();
            }
            catch
            {
                return null;
            }
        }

        // GET api/<CausasController>/5
        // Recibe un codigo de causa y devuelve la correspondiente
        [HttpGet("{codigo}")]
        public Causas Get(int codigo)
        {                   
            try
            {
                return db.Causas.FirstOrDefault(c => c.Codigo == codigo);
            }
            catch
            {
                return null;
            }

        }
    }
}
