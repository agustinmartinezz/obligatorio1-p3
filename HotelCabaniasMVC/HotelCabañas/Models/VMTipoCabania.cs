namespace HotelCabañas.Models
{
    public class VMTipoCabania
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CostoxHuesped { get; set; }

        public VMTipoCabania()
        {
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }
    }
}
