using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IESTest05.Entity
{
    public partial class Fichajes
    {
        [StringLength(10)]
        public string Personal { get; set; }
        [Key]
        [Column(TypeName = "smalldatetime")]
        public DateTime Hora { get; set; }
        public byte? Terminal { get; set; }
        public byte? Funcion { get; set; }
        [Key]
        [StringLength(13)]
        public string Tarjeta { get; set; }
        public short? Causa { get; set; }
        public byte? Tipo { get; set; }
        [StringLength(10)]
        public string Centro { get; set; }
        [Key]
        public short Estado { get; set; }
        public int RefDisparo { get; set; }
        [Column(TypeName = "decimal(9, 6)")]
        public decimal? Longitud { get; set; }
        [Column(TypeName = "decimal(9, 6)")]
        public decimal? Latitud { get; set; }
        public byte ExportWAF { get; set; }
        public short TimeZoneOffset { get; set; }
        [StringLength(100)]
        public string TimeZone { get; set; }

        [ForeignKey(nameof(Personal))]
        [InverseProperty("Fichajes")]
        public virtual Personal PersonalNavigation { get; set; }
    }
}
