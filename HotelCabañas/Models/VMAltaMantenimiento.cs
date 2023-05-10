using LogicaNegocio.EntidadesNegocio;

namespace HotelCabañas.Models
{
    public class VMAltaMantenimiento
    {
        public Mantenimiento Mantenimiento { get; set; }

        public int CabaniaId { get; set; }

        public VMAltaMantenimiento() { 
            Mantenimiento = new Mantenimiento();
            Mantenimiento.Fecha = DateTime.Now;
        }
    }
}
