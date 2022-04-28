using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileLite.Entities
{
    public class TUsuarios
    {
        public string Nombre { get; set; }
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public byte? Nivel { get; set; }
        public string Permisos { get; set; }
        public string Email { get; set; }
        public byte Bloqueado { get; set; }
        public string Dominio { get; set; }
        public string Personal { get; set; }
        public byte? Responsable { get; set; }
        public string Avatar { get; set; }
        public byte Estado { get; set; }
        public string Cdesbloqueo { get; set; }
        public DateTime? Fdesbloqueo { get; set; }
        public short Nreintentos { get; set; }
        public byte Visitas { get; set; }
        public String Token { get; set; }
    }
}
