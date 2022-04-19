using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IESTest05.Entity
{
    [Table("Validacion")]
    public partial class Validacion
    {
        public Validacion()
        {
            VContadores = new HashSet<VContadores>();
            VFichajes = new HashSet<VFichajes>();
            VIncidencia = new HashSet<VIncidencias>();
        }

        [Key]
        [StringLength(10)]
        public string Personal { get; set; }
        [Key]
        [Column(TypeName = "smalldatetime")]
        public DateTime Fecha { get; set; }
        [Required]
        [StringLength(3)]
        public string Horario { get; set; }
        public byte TipoFestivo { get; set; }
        public byte TipoControl { get; set; }
        public byte Estado { get; set; }
        public short Inicio { get; set; }
        public short Fin { get; set; }
        [StringLength(10)]
        public string Centro { get; set; }
        [StringLength(10)]
        public string Departamento { get; set; }
        [StringLength(10)]
        public string Seccion { get; set; }
        [StringLength(10)]
        public string Empresa { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FREV10 { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FREV20 { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FREV30 { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FREV40 { get; set; }
        public byte Aux { get; set; }

        [ForeignKey(nameof(Personal))]
        [InverseProperty("Validacions")]
        public virtual Personal PersonalNavigation { get; set; }
        [InverseProperty(nameof(Entity.VContadores.Validacion))]
        public virtual ICollection<VContadores> VContadores { get; set; }
        [InverseProperty(nameof(Entity.VFichajes.Validacion))]
        public virtual ICollection<VFichajes> VFichajes { get; set; }
        [InverseProperty("Validacion")]
        public virtual ICollection<VIncidencias> VIncidencia { get; set; }
    }
}
