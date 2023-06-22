namespace HotelCabañas.Models
{
    public class VMCabania
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public VMTipoCabania? TipoCabania { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool TieneJacuzzi { get; set; }

        public bool HabilitadaReservas { get; set; }

        public int NumeroHabitacion { get; set; }

        public int MaxPersonas { get; set; }
        public string Foto { get; set; }



        public VMCabania()
        {
            //TipoCabania = new VMTipoCabania();
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Foto = string.Empty;
        }
    }
}
