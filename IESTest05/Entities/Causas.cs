using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MobileLite.Context;

namespace MobileLite.Entities
{

    public class Causas
    {
        [Key]
        public short codigo { get; set; }
        public string descripcion { get; set; }
        public byte aprobar { get; set; }
        public byte? solicitud { get; set; }
        public string referencia { get; set; }
        public byte tweb { get; set; }
        public byte? calculodiasnaturales { get; set; }
        public string? pldocs { get; set; }
    }
}
