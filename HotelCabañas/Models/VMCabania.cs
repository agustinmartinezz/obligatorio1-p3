using LogicaNegocio.EntidadesNegocio;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace HotelCabañas.Models
{
    public class VMCabania
    {

        //public int TipoId { get; set; }
        //public string Nombre { get; set; }
        //public string Descripcion { get; set; }
        public string TieneJacuzzi { get; set; }
        public string HabilitadaReservas { get; set; }
        //public int NumeroHabitacion { get; set; }
        //public static int UltimoNumHab { get; set; }
        //public int MaxPersonas { get; set; }
        public IFormFile Foto { get; set; }

        public Cabania? Cabania { get; set; }

        public String? strSearchCabania { get; set; }
        public int? searchTypeCabania { get; set; }
        public IEnumerable<TipoCabania>? Tipos { get; set; }
        public IEnumerable<Cabania>? Cabanias { get; set; }
    }
}
