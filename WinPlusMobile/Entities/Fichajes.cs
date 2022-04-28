using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileLite.Entities
{
    public class Fichajes
    {
        public Fichajes(string Personal, DateTime Hora, byte terminal, byte funcion, string tarjeta,
            short causa, byte tipo, string centro, short estado, int refdisparo, double latitud, 
            double longitud, byte exportwaf, short timezoneoffser, string timezone)
        {
            this.Personal = Personal;
            this.Terminal = terminal;
            this.Hora = Hora;
            this.Funcion = funcion;
            this.Causa = causa;
            this.Centro = centro;
            this.Tarjeta = tarjeta;
            this.Tipo = tipo;
            this.Estado = estado;
            this.RefDisparo = refdisparo;
            this.Latitud = latitud;
            this.Longitud = longitud;
            this.ExportWaf = exportwaf;
            this.TimeZone = timezone;
            this.TimeZoneOffset = timezoneoffser;
        }

        public Fichajes()
        {
        }

        public string Personal { get; set; }
        [Key]
        public DateTime Hora { get; set; }
        public byte Terminal { get; set; }
        public byte Funcion { get; set; }
        [Key]
        public string Tarjeta { get; set; }
        public short Causa { get; set; }
        public byte Tipo { get; set; }
        public string Centro { get; set; }
        [Key]
        public short Estado { get; set; }
        public int RefDisparo { get; set; }
        public double Longitud { get; set; }
        public double Latitud { get; set; }
        public byte ExportWaf { get; set; }
        public short TimeZoneOffset { get; set; }
        public string TimeZone { get; set; }
    }
}
