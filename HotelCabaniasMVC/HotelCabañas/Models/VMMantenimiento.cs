namespace HotelCabañas.Models
{
    public class VMMantenimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Costo { get; set; }
        public string NombreRealizo { get; set; }
        public int CabaniaId { get; set; }
    }
}
