using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IESTest05.Entity
{
    [Index(nameof(Contador), Name = "FK_VCONT_CONT")]
    [Index(nameof(Personal), nameof(Fecha), Name = "FK_VCONT_PERFEC")]
    public partial class VContadores
    {
        [Key]
        [StringLength(10)]
        public string Personal { get; set; }
        [Key]
        [Column(TypeName = "smalldatetime")]
        public DateTime Fecha { get; set; }
        [Key]
        public short Contador { get; set; }
        public short Valor { get; set; }
        public short Manual { get; set; }

        [ForeignKey(nameof(Contador))]
        [InverseProperty(nameof(Contadores.VContadores))]
        public virtual Contadores ContadorNavigation { get; set; }
        [ForeignKey("Personal,Fecha")]
        [InverseProperty("VContadores")]
        public virtual Validacion Validacion { get; set; }
    }
}
