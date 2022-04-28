using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileLite.Entities
{//
    public class Contadores
    {
        [Key]
        public short Codigo { get; set; }
        public string Descripcion { get; set; }
        public byte Tipo { get; set; }
        public byte Redondeo { get; set; }
        public byte Limite { get; set; }
        public byte Clase { get; set; }
        public string Referencia { get; set; }
        public byte Revision { get; set; }
        public int TopeMax { get; set; }
        public byte? Periodo { get; set; }
        public string Causas { get; set; }
        public short? Finicio { get; set; }
        public byte? Consultar { get; set; }
    }
}
