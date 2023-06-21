namespace HotelCabañas.Models
{
    public class VMIndexMantenimiento
    {
        public IEnumerable<VMMantenimiento> Mantenimientos { get; set; }
        public VMMantenimiento Mantenimiento { get; set; }
        public VMCabania Cabania { get; set; }
        public VMBusqueda Busqueda { get; set; }

        public VMIndexMantenimiento()
        {
            Mantenimientos = new List<VMMantenimiento>();
            Mantenimiento = new VMMantenimiento();
            Cabania = new VMCabania();
            Busqueda = new VMBusqueda();

        }
    }
}
