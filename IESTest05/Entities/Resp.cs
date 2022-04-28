using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileLite.Entities
{
    public class Resp
    {
        public Resp(int codigo, string descripcion, string datos)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Datos = datos;
        }

        public Resp(int codigo, string descripcion)
        {
            Codigo = codigo;
            Descripcion = descripcion;
        }

        public Resp() { }

        public int Codigo { get; set; }
        public String Descripcion { get; set; }
        public String Datos { get; set; }
    }

}
