namespace HotelCabañas.Models
{
    public class VMIndexCabania
    {
        public IEnumerable<VMCabania> Cabanias { get; set; }
        public IEnumerable<VMTipoCabania> TiposCabania { get; set; }
        public VMBusqueda Busqueda { get; set; }
        public VMCabania Cabania { get; set; }
    }
}
