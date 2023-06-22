using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObjects;


namespace DTOs
{
    [NotMapped]
    public class DTOCabania

    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public DTOTipoCabania? TipoCabania { get; set; }
        
        public string Nombre { get; set; }
    
        public string Descripcion { get; set; }
        
        public bool TieneJacuzzi { get; set; }
        
        public bool HabilitadaReservas { get; set; }

        public int NumeroHabitacion { get; set; }
        
        public int MaxPersonas { get; set; }

        public string Foto { get; set; }
    }
}