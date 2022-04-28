using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MobileLite.Entities
{
    public class Personal
    {
        [Key]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Tarjeta { get; set; }
        public string Telefono { get; set; }
        public string Centro { get; set; }
        public string Departamento { get; set; }
        public string Seccion { get; set; }
        public string Categoria { get; set; }
        public string Dni { get; set; }
        public string Calendario { get; set; }
        public byte TipoControl { get; set; }
        public byte SalidaAutomatica { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? UltimoFichaje { get; set; }
        public byte UltimaFuncion { get; set; }
        public byte UltimaCausa { get; set; }
        public string Foto { get; set; }
        public int Saldo1 { get; set; }
        public int Saldo2 { get; set; }
        public int Saldo3 { get; set; }
        public int Saldo4 { get; set; }
        public string Observaciones { get; set; }
        public string Sexo { get; set; }
        public string Password { get; set; }
        public short? Cgastos1 { get; set; }
        public short? Cgastos2 { get; set; }
        public short? Cgastos3 { get; set; }
        public float Pcgastos1 { get; set; }
        public float Pcgastos2 { get; set; }
        public float Pcgastos3 { get; set; }
        public string Perfil { get; set; }
        public DateTime? UltimoAcceso { get; set; }
        public string Empresa { get; set; }
        public short? Permisos { get; set; }
        public byte? Conprod { get; set; }
        public string Pcoste { get; set; }
        public string ResCen { get; set; }
        public string ResDep { get; set; }
        public string AdjDep { get; set; }
        public string SecDep { get; set; }
        public byte? Facceso { get; set; }
        public string Colectivo { get; set; }
        public string EmpresaExterna { get; set; }
        public string Email { get; set; }
        public DateTime? UltimaFicha { get; set; }
        public string Pin { get; set; }
        public byte Bloqueado { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Cpostal { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime? Fnacimiento { get; set; }
        public string Pais { get; set; }
        public string UltimoLocal { get; set; }
        public bool? Vantipassback { get; set; }
        public byte? NotRescen { get; set; }
        public byte? NotResDep { get; set; }
        public byte? NotAdjDep { get; set; }
        public byte? NotSecDep { get; set; }
        public int? SaldoInicial { get; set; }
        public byte? Wpmobile { get; set; }
        public string TarjetaCi { get; set; }
        public string Salto_ExtUserId { get; set; }
        public byte Estado { get; set; }
        public string Cdesbloqueo { get; set; }
        public DateTime? Fdesbloqueo { get; set; }
        public short Nreintentos { get; set; }
        public string UltimoCentro { get; set; }
    }
}
