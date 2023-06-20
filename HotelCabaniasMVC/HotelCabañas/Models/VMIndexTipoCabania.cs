namespace HotelCabañas.Models
{
    public class VMIndexTipoCabania
    {
        public IEnumerable<VMTipoCabania> TiposCabania { get; set; }

        public VMBusqueda Busqueda { get; set; }

        public VMIndexTipoCabania()
        {
            TiposCabania = new List<VMTipoCabania>();
            Busqueda = new VMBusqueda();
        }
    }
}
