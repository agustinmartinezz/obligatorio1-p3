using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    [Index("TextoContrasenia")]
    public class Contrasenia : IValidar
    {

        public string TextoContrasenia { get; }

        public Contrasenia(string textoContrasenia)
        {
            this.TextoContrasenia = textoContrasenia;
            //ValidarDatos();
        }

        private Contrasenia() { }

        public void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(TextoContrasenia))
                throw new ContraseniaException("Contraseña no puede ser nulo o vacio.");

            bool mayus = Regex.IsMatch(TextoContrasenia, @"[A-ZÑ]");
            bool minus = Regex.IsMatch(TextoContrasenia, @"[a-zñ]");
            bool num = Regex.IsMatch(TextoContrasenia, @"\d");

            if (!mayus && !minus && !num && !(TextoContrasenia.Length >= 6))
                throw new ContraseniaException("Contraseña debe tener al menos 6 caracteres e incluir minúscula, mayúscula y número.");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Contrasenia contrasenia = (Contrasenia) obj;
            return TextoContrasenia.Equals(contrasenia.TextoContrasenia);
        }
    }
}
