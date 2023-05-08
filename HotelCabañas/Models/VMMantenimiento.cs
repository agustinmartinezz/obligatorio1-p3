using LogicaNegocio.EntidadesNegocio;

namespace HotelCabañas.Models
{
    public class VMMantenimiento
    {

        public DateTime date1 { get; set; }
        public DateTime date2 { get; set; }
        public IEnumerable<Cabania> Cabanias { get; set; }

        public Cabania Cabania { get; set; }

        public Mantenimiento Mantenimiento { get; set; }
        public IEnumerable<Mantenimiento> Mantenimientos { get; set; }

    }
}
