using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileLite.Entities
{
    public class VContadores
    {
        [Key]
        public string Personal { get; set; }
        [Key]
        public DateTime Fecha { get; set; }
        [Key]
        public short Contador { get; set; }
        public short Valor { get; set; }
        public short Manual { get; set; }
    }
}
