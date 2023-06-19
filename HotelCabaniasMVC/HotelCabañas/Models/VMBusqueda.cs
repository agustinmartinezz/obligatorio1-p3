namespace HotelCabañas.Models
{
    public class VMBusqueda
    {
        public string? SearchText { get; set; } //1
        public int SearchType { get; set; } //2 - TipoId
        public int SearchNumber { get; set; } //3
        public int SearchOption { get; set; } //1,2,3,4
        public DateTime Fecha1 { get; set; }
        public DateTime Fecha2 { get; set; }

        //Para el constructor???
        //Fecha1 = DateTime.Now.AddMonths(-1);
        //Fecha2 = DateTime.Now;
    }
}
