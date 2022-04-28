using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileLite.Entities
{
    public class Config
    {
        [Key]
        public String clave { get; set; }
        public String valor { get; set; }
        public byte tipo { get; set; }
        public String descripcion { get; set; }
    }
}
