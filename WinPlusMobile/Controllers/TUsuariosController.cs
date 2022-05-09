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
        [HttpPost] // POST: api/tusuarios
        [Route("{validar}")]
        public Resp Get([FromForm] String token)
        {
            try
            {
                var usuario = db.TUsuarios.FirstOrDefault(u => u.Token == token);
                if (usuario != null)
                    return new Resp(0, "Token válido");

                return null;
            }
            catch
            {
                return null;
            }
        }

        // In: Login, password | Autenticacion de usuarios
        [HttpPost] // POST: api/tusuarios
        public Resp Post([FromForm] String login, [FromForm] String password)
        {
            try
            {
                TUsuarios usuario = db.TUsuarios.FirstOrDefault(u => u.Login == login);

                if (usuario == null)
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
    }
}