using LogicaNegocio.EntidadesNegocio;

namespace HotelCabañas.Models
{
    public class VMCabania
    {
        public string TieneJacuzzi { get; set; }

        public string HabilitadaReservas { get; set; }

        public IFormFile Foto { get; set; }

        public Cabania? Cabania { get; set; }

        public String? strSearchCabania { get; set; }
        public int? searchTypeCabania { get; set; }
        public IEnumerable<TipoCabania>? Tipos { get; set; }
        public IEnumerable<Cabania>? Cabanias { get; set; }
    }
}
