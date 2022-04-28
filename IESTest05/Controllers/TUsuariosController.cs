using System;
using System.Linq;
using IESTest05.Data;
using IESTest05.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileLite.Entities;

namespace IESTest05.Controllers
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

        // GET api/tusuarios/token
        // Recibe com parametro de entrada el token de sesion y devuelve los datos del usuario
        [HttpGet("{Token}")]
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

        // POST: api/tusuarios
        // Autenticacion de usuarios
        [HttpPost]
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