using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IESTest05.Entity
{
    public partial class Incidencias
    {
        public Incidencias()
        {
            VIncidencia = new HashSet<VIncidencias>();
        }

        [Key]
        public short Codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        public short Causa { get; set; }
        public byte Parametro { get; set; }
        public byte? Solicitud { get; set; }

        [InverseProperty("IncidenciaNavigation")]
        public virtual ICollection<VIncidencias> VIncidencia { get; set; }
    }
}
