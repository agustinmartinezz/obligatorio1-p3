using LogicaNegocio.EntidadesNegocio;

namespace HotelCabañas.Models
{
    public class VMMantenimiento
    {
        public int IdCabania { get; set; }
        public DateTime Fecha1 { get; set; }
        public DateTime Fecha2 { get; set; }

        public Cabania Cabania { get; set; }
        public IEnumerable<Mantenimiento> Mantenimientos { get; set; }


        public VMMantenimiento() 
        {
            Fecha1 = DateTime.Now.AddMonths(-1);
            Fecha2 = DateTime.Now;
            this.Cabania = new Cabania();
            this.Mantenimientos = new List<Mantenimiento>();
        }

        public VMMantenimiento(int idCabania, DateTime fecha1, DateTime fecha2, Cabania cabania)
        {
            IdCabania = idCabania;
            Fecha1 = fecha1;
            Fecha2 = fecha2;
            Cabania = cabania;
            this.Mantenimientos = new List<Mantenimiento>();
        }
    }
}
