using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileLite.Entities
{
    public class Validacion
    {
        [Key]
        public string Personal { get; set; }
        [Key]
        public DateTime Fecha { get; set; }
        public string Horario { get; set; }
        public byte TipoFestivo { get; set; }
        public byte TipoControl { get; set; }
        public byte Estado { get; set; }
        public short Inicio { get; set; }
        public short Fin { get; set; }
        public string Centro { get; set; }
        public string Departamento { get; set; }
        public string Seccion { get; set; }
        public string Empresa { get; set; }
        public DateTime? Frev10 { get; set; }
        public DateTime? Frev20 { get; set; }
        public DateTime? Frev30 { get; set; }
        public DateTime? Frev40 { get; set; }
        public byte Aux { get; set; }
    }
}
