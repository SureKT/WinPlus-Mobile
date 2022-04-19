using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IESTest05.Entity
{
    public partial class Acumulados
    {
        [Key]
        [StringLength(10)]
        public string Personal { get; set; }
        [Key]
        [Column(TypeName = "smalldatetime")]
        public DateTime Inicio { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime Fin { get; set; }
        [Key]
        public short Actividad { get; set; }
        public int Valor { get; set; }
        public byte Estado { get; set; }

        [ForeignKey(nameof(Personal))]
        [InverseProperty("Acumulados")]
        public virtual Personal PersonalNavigation { get; set; }
    }
}
