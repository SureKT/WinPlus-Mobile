using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IESTest05.Entity
{
    public partial class Contadores
    {
        public Contadores()
        {
            VContadores = new HashSet<VContadores>();
        }

        [Key]
        public short Codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        public byte Tipo { get; set; }
        public byte Redondeo { get; set; }
        public byte Limite { get; set; }
        public byte Clase { get; set; }
        [StringLength(10)]
        public string Referencia { get; set; }
        public byte Revision { get; set; }
        public int TopeMax { get; set; }
        public byte? Periodo { get; set; }
        [StringLength(40)]
        public string Causas { get; set; }
        public short? FInicio { get; set; }
        public byte? Consultar { get; set; }

        [InverseProperty(nameof(Entity.VContadores.ContadorNavigation))]
        public virtual ICollection<VContadores> VContadores { get; set; }
    }
}
