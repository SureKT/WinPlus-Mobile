using System.ComponentModel.DataAnnotations;

namespace MobileLite.Entities
{

    public class Causas
    {
        [Key]
        public short Codigo { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        public byte Aprobar { get; set; }
        public byte? Solicitud { get; set; }
        [StringLength(10)]
        public string Referencia { get; set; }
        public byte? TWEB { get; set; }
        public byte? CalculoDiasNaturales { get; set; }
        [StringLength(5)]
        public string PLDOCS { get; set; }
        public byte? TWEBEntrada { get; set; }
    }
}
