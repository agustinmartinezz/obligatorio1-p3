using LogicaNegocio.EntidadesNegocio;

namespace HotelCabañas.Models
{
    public class VMCabania
    {
        public string TieneJacuzzi { get; set; }

        public string HabilitadaReservas { get; set; }

        public IFormFile Foto { get; set; }

        public Cabania? Cabania { get; set; }


        public string? SearchText { get; set; } //1
        public int SearchType { get; set; } //2 - TipoId
        public int SearchNumber { get; set; } //3
        public int SearchOption { get; set; } //1,2,3,4

        public IEnumerable<TipoCabania>? Tipos { get; set; }
        public IEnumerable<Cabania>? Cabanias { get; set; }
    }
}
