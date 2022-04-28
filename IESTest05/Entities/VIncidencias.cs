using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IESTest05.Entity
{
    public partial class VIncidencias
    {
        [Key]
        [StringLength(10)]
        public string Personal { get; set; }
        [Key]
        [Column(TypeName = "smalldatetime")]
        public DateTime Fecha { get; set; }
        [Key]
        public short Incidencia { get; set; }
        [Key]
        public short Causa { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Indice { get; set; }

        [ForeignKey(nameof(Causa))]
        [InverseProperty("VIncidencia")]
        public virtual Causas CausaNavigation { get; set; }
        [ForeignKey(nameof(Incidencia))]
        [InverseProperty("VIncidencia")]
        public virtual Incidencias IncidenciaNavigation { get; set; }
        [ForeignKey("Personal,Fecha")]
        [InverseProperty("VIncidencia")]
        public virtual Validacion Validacion { get; set; }
    }
}
