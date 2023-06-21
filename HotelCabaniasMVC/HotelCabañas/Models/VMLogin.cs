namespace HotelCabañas.Models
{
    public class VMLogin
    {
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public VMLogin()
        {
            Email = string.Empty;
            Contrasenia = string.Empty;
        }
    }
}
