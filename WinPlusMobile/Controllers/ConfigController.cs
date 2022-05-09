using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WinPlusMobile.Data;
using MobileLite.Entities;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobileLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly DataContext db;

        public ConfigController(DataContext context)
        {
            db = context;
        }

        // In: Clave de config | Out: Objeto Config
        [HttpPost] // POST: api/config
        public Config Post([FromForm] String clave)
        {
            try
            {
                return db.Config.FirstOrDefault(c => c.clave == clave);
            }
            catch
            {
                return null;
            }
        }
    }
}
