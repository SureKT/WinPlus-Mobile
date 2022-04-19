using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IESTest05.Entity
{
    public partial class Causas
    {
        public Causas()
        {
            VIncidencia = new HashSet<VIncidencias>();
        }

        [Key]
        public short Codigo { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        public byte Aprobar { get; set; }
        public byte? Solicitud { get; set; }
        [StringLength(10)]
        public string Referencia { get; set; }
        public byte? TWEB { get; set; }
        public byte? CalculoDiasNaturales { get; set; }
        [StringLength(5)]
        public string PLDOCS { get; set; }
        public byte? TWEBEntrada { get; set; }

        [InverseProperty("CausaNavigation")]
        public virtual ICollection<VIncidencias> VIncidencia { get; set; }
    }
}
