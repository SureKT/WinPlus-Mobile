using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IESTest05.Entity
{
    public partial class TUsuarios
    {
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
        [Key]
        [StringLength(15)]
        public string Login { get; set; }
        [StringLength(35)]
        public string Password { get; set; }
        public byte? Nivel { get; set; }
        [StringLength(400)]
        public string Permisos { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public byte Bloqueado { get; set; }
        [StringLength(50)]
        public string Dominio { get; set; }
        [StringLength(10)]
        public string Personal { get; set; }
        public byte? Responsable { get; set; }
        [StringLength(255)]
        public string Avatar { get; set; }
        public byte Estado { get; set; }
        [StringLength(50)]
        public string CDesbloqueo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FDesbloqueo { get; set; }
        public byte Visitas { get; set; }
        public short NReintentos { get; set; }
        [StringLength(255)]
        public string Token { get; set; }
    }
}
