using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IESTest05.Entity
{
    public partial class VFichajes
    {
        [Key]
        [StringLength(10)]
        public string Personal { get; set; }
        [Key]
        [Column(TypeName = "smalldatetime")]
        public DateTime Fecha { get; set; }
        [Key]
        [Column(TypeName = "smalldatetime")]
        public DateTime Hora { get; set; }
        [Key]
        public byte Funcion { get; set; }
        public short Causa { get; set; }
        [StringLength(10)]
        public string Centro { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Indice { get; set; }
        public byte Aux { get; set; }
        public byte Tipo { get; set; }

        [ForeignKey("Personal,Fecha")]
        [InverseProperty("VFichajes")]
        public virtual Validacion Validacion { get; set; }
    }
}
