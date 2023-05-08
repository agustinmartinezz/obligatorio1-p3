using LogicaNegocio.EntidadesNegocio;

namespace HotelCabañas.Models
{
    public class VMTiposCabana
    {
        public string StrSearch { get; set; }
        public IEnumerable<TipoCabana> TiposCabana { get; set; }

        public VMTiposCabana()
        {
            StrSearch = string.Empty;
            TiposCabana = new List<TipoCabana>();
        }
    }
}
