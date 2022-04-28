using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IESTest05.Data;
using MobileLite.Entities;

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

        // GET api/config/5
        [HttpGet("{id}")]
        public Config Get(String id)
        {           
            try
            {
                return db.Config.FirstOrDefault(c => c.clave == id);
            }
            catch
            {
                return null;
            }
        }
    }
}
