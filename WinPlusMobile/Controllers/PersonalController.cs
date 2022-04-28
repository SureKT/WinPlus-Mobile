using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WinPlusMobile.Data;
using MobileLite.Entities;

namespace WinPlusMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly DataContext db;

        public PersonalController(DataContext context)
        {
            db = context;
        }

        // In: Token | Out: Personal correspondiente al token
        [HttpGet("{Token}")] // GET api/personal
        public Personal Get(String token)
        {
            try
            {
                TUsuarios usuario = db.TUsuarios.FirstOrDefault(u => u.Token == token);
                Personal personal = db.Personal.FirstOrDefault(u => u.Codigo == usuario.Personal);
                return personal;
            }
            catch
            {
                return null;
            }

        }

        
        // In: Token | Out: String de foto de usuario codificada en base 64
        [HttpPost("{Token}")] // POST api/personal
        public String Post(String token)
        {
            try
            {
                Config dirFoto = db.Config.FirstOrDefault(c => c.clave == "DirFotos");
                TUsuarios usuario = db.TUsuarios.FirstOrDefault(u => u.Token == token);
                Personal personal = db.Personal.FirstOrDefault(p => p.Codigo == usuario.Personal);
                Byte[] b = System.IO.File.ReadAllBytes(dirFoto.valor + personal.Foto);
                return Convert.ToBase64String(b);
            }
            catch
            {
                return null;
            }
        }
    }
}
