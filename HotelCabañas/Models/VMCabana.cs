using LogicaNegocio.EntidadesNegocio;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace HotelCabañas.Models
{
    public class VMCabana {
        public int TipoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Boolean TieneJacuzzi { get; set; }
        public Boolean HabilitadaReservas { get; set; }
        public int NumeroHabitacion { get; set; }
        public static int UltimoNumHab { get; set; }
        public int MaxPersonas { get; set; }
        public IFormFile Foto { get; set; }

        public Cabana? Cabana { get; set; }

        public String? strSearchCabana { get; set; }
        public int? searchTypeCabana { get; set; }
        public IEnumerable<TipoCabana>? Tipos { get; set; }
        public IEnumerable<Cabana>? Cabanas { get; set; }
        
    
    }
}
