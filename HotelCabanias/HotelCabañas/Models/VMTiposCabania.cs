using LogicaNegocio.EntidadesNegocio;

namespace HotelCabañas.Models
{
    public class VMTiposCabania
    {
        public string StrSearch { get; set; }
        public IEnumerable<TipoCabania> TiposCabania { get; set; }

        public VMTiposCabania()
        {
            StrSearch = string.Empty;
            TiposCabania = new List<TipoCabania>();
        }
    }
}
