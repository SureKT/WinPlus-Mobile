using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MobileLite.Entities
{
    public class VFichajes
    {
        public VFichajes(string Personal, DateTime Fecha, DateTime Hora, byte funcion, short causa, String centro, byte aux, byte tipo)
        {
            this.Personal = Personal;
            this.Fecha = Fecha;
            this.Hora = Hora;
            this.Funcion = funcion;
            this.Causa = causa;
            this.Centro = centro;
            this.Aux = aux;
            this.Tipo = tipo;
        }

        [Key]
        public string Personal { get; set; }
        [Key]
        public DateTime Fecha { get; set; }
        [Key]
        public DateTime Hora { get; set; }
        [Key]
        public byte Funcion { get; set; }
        public short Causa { get; set; }
        public string Centro { get; set; }

        //public decimal Indice { get; set; }
        public byte Aux { get; set; }
        public byte Tipo { get; set; }
    }
}
