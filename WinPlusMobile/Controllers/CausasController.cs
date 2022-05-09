using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WinPlusMobile.Data;
using MobileLite.Entities;

namespace WinPlusMobile.Controllers
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

        // Out: Listado de causas
        [HttpGet] // GET: api/causas
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


        // In: Codigo de causa | Out: Causa correspondiente
        [HttpGet("{codigo}")] // GET api/causas/5
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
