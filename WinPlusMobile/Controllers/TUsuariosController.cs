using System;
using System.Linq;
using WinPlusMobile.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileLite.Entities;

namespace WinPlusMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TUsuariosController : ControllerBase
    {
        private readonly DataContext db;

        public TUsuariosController(DataContext context)
        {
            db = context;
        }

        // In: Token | Out: TUsuario correspondiente al token
        [HttpGet("{Token}")] // GET api/tusuarios/token
        public TUsuarios Get(String token)
        {
            try
            {
                return db.TUsuarios.FirstOrDefault(u => u.Token == token);
            }
            catch
            {
                return null;
            }
        }

        // In: Login, password | Autenticacion de usuarios
        [HttpPost] // POST: api/tusuarios
        public Resp Post(String login, String password)
        {
            try
            {
                TUsuarios usuario = db.TUsuarios.FirstOrDefault(u => u.Login == login);

                if (!TUsuariosExists(login))
                    return new Resp(1, "Usuario no encontrado");

                if (!usuario.Password.Equals(password))
                    return new Resp(2, "Contraseña incorrecta");

                String token = Guid.NewGuid().ToString();

                usuario.Token = token;
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();

                return new Resp(0, "Correcto", token);
            }
            catch
            {
                return null;
            }
        }

        private bool TUsuariosExists(string id)
        {
            return db.TUsuarios.Any(e => e.Login == id);
        }
    }
}