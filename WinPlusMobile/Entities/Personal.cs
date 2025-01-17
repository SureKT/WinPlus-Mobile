﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileLite.Entities
{
    public class Personal
    {
        //[Key]
        //public string Codigo { get; set; }
        //public string Nombre { get; set; }
        //public string Apellido1 { get; set; }
        //public string Apellido2 { get; set; }
        //public string Tarjeta { get; set; }
        //public string Telefono { get; set; }
        //public string Centro { get; set; }
        //public string Departamento { get; set; }
        //public string Seccion { get; set; }
        //public string Categoria { get; set; }
        //public string Dni { get; set; }
        //public string Calendario { get; set; }
        //public byte TipoControl { get; set; }
        //public byte SalidaAutomatica { get; set; }
        //public DateTime? FechaIngreso { get; set; }
        //public DateTime? FechaBaja { get; set; }
        //public DateTime? UltimoFichaje { get; set; }
        //public byte UltimaFuncion { get; set; }
        //public byte UltimaCausa { get; set; }
        //public string Foto { get; set; }
        //public int Saldo1 { get; set; }
        //public int Saldo2 { get; set; }
        //public int Saldo3 { get; set; }
        //public int Saldo4 { get; set; }
        //public string Observaciones { get; set; }
        //public string Sexo { get; set; }
        //public string Password { get; set; }
        //public short? Cgastos1 { get; set; }
        //public short? Cgastos2 { get; set; }
        //public short? Cgastos3 { get; set; }
        //public float Pcgastos1 { get; set; }
        //public float Pcgastos2 { get; set; }
        //public float Pcgastos3 { get; set; }
        //public string Perfil { get; set; }
        //public DateTime? UltimoAcceso { get; set; }
        //public string Empresa { get; set; }
        //public short? Permisos { get; set; }
        //public byte? Conprod { get; set; }
        //public string Pcoste { get; set; }
        //public string ResCen { get; set; }
        //public string ResDep { get; set; }
        //public string AdjDep { get; set; }
        //public string SecDep { get; set; }
        //public byte? Facceso { get; set; }
        //public string Colectivo { get; set; }
        //public string EmpresaExterna { get; set; }
        //public string Email { get; set; }
        //public DateTime? UltimaFicha { get; set; }
        //public string Pin { get; set; }
        //public byte Bloqueado { get; set; }
        //public string Direccion { get; set; }
        //public string Localidad { get; set; }
        //public string Provincia { get; set; }
        //public string Cpostal { get; set; }
        //public string EstadoCivil { get; set; }
        //public DateTime? Fnacimiento { get; set; }
        //public string Pais { get; set; }
        //public string UltimoLocal { get; set; }
        //public bool? Vantipassback { get; set; }
        //public byte? NotRescen { get; set; }
        //public byte? NotResDep { get; set; }
        //public byte? NotAdjDep { get; set; }
        //public byte? NotSecDep { get; set; }
        //public int? SaldoInicial { get; set; }
        //public byte? Wpmobile { get; set; }
        //public string TarjetaCi { get; set; }
        //public string Salto_ExtUserId { get; set; }
        //public byte Estado { get; set; }
        //public string Cdesbloqueo { get; set; }
        //public DateTime? Fdesbloqueo { get; set; }
        //public short Nreintentos { get; set; }
        //public string UltimoCentro { get; set; }

        [Key]
        [StringLength(10)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido1 { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido2 { get; set; }
        [StringLength(13)]
        public string Tarjeta { get; set; }
        [Required]
        [StringLength(30)]
        public string Telefono { get; set; }
        [StringLength(10)]
        public string Centro { get; set; }
        [StringLength(10)]
        public string Departamento { get; set; }
        [StringLength(10)]
        public string Seccion { get; set; }
        [StringLength(10)]
        public string Categoria { get; set; }
        [Required]
        [StringLength(12)]
        public string DNI { get; set; }
        [StringLength(5)]
        public string Calendario { get; set; }
        public byte TipoControl { get; set; }
        public byte SalidaAutomatica { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaIngreso { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaBaja { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? UltimoFichaje { get; set; }
        public byte UltimaFuncion { get; set; }
        public byte UltimaCausa { get; set; }
        [StringLength(255)]
        public string Foto { get; set; }
        public int Saldo1 { get; set; }
        public int Saldo2 { get; set; }
        public int Saldo3 { get; set; }
        public int Saldo4 { get; set; }
        [Required]
        [StringLength(1000)]
        public string Observaciones { get; set; }
        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }
        [StringLength(35)]
        public string Password { get; set; }
        public short? CGastos1 { get; set; }
        public short? CGastos2 { get; set; }
        public short? CGastos3 { get; set; }
        public float PCGastos1 { get; set; }
        public float PCGastos2 { get; set; }
        public float PCGastos3 { get; set; }
        [StringLength(5)]
        public string Perfil { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UltimoAcceso { get; set; }
        [StringLength(10)]
        public string Empresa { get; set; }
        public short? Permisos { get; set; }
        public byte? Conprod { get; set; }
        [StringLength(10)]
        public string PCoste { get; set; }
        [StringLength(10)]
        public string ResCen { get; set; }
        [StringLength(10)]
        public string ResDep { get; set; }
        [StringLength(10)]
        public string AdjDep { get; set; }
        [StringLength(10)]
        public string SecDep { get; set; }
        public byte? FAcceso { get; set; }
        [StringLength(10)]
        public string Colectivo { get; set; }
        [StringLength(10)]
        public string EmpresaExterna { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? UltimaFicha { get; set; }
        [StringLength(10)]
        public string PIN { get; set; }
        public byte Bloqueado { get; set; }
        [StringLength(50)]
        public string Direccion { get; set; }
        [StringLength(30)]
        public string Localidad { get; set; }
        [StringLength(30)]
        public string Provincia { get; set; }
        [StringLength(6)]
        public string CPostal { get; set; }
        [StringLength(20)]
        public string EstadoCivil { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FNacimiento { get; set; }
        [StringLength(30)]
        public string Pais { get; set; }
        [StringLength(10)]
        public string UltimoLocal { get; set; }
        public bool? VAntipassback { get; set; }
        public byte? NotRescen { get; set; }
        public byte? NotResDep { get; set; }
        public byte? NotAdjDep { get; set; }
        public byte? NotSecDep { get; set; }
        public int? SaldoInicial { get; set; }
        public byte? WPMobile { get; set; }
        public short TipoCalendario { get; set; }
        [StringLength(10)]
        public string CSecuencia { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaSecuencia { get; set; }
        [StringLength(10)]
        public string TarjetaCI { get; set; }
        [StringLength(32)]
        public string Salto_ExtUserID { get; set; }
        public byte Estado { get; set; }
        [StringLength(50)]
        public string CDesbloqueo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FDesbloqueo { get; set; }
        public short NReintentos { get; set; }
    }
}
