using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario:IValidar
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        [EmailAddress]
        public string Mail { get; set; }

        public string Contrasena { get; set; }

        public Usuario(string nombre, string mail, string contrasena) {
            Nombre = nombre;
            Mail = mail;
            Contrasena = contrasena;
        }

        public void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new UsuarioException("Nombre no puede ser nulo o vacio.");

            if (string.IsNullOrWhiteSpace(Mail))
                throw new UsuarioException("Mail no puede ser nulo o vacio.");

            if (string.IsNullOrWhiteSpace(Contrasena))
                throw new UsuarioException("Contraseña no puede ser nulo o vacio.");

            if (!ValidacionesContrasenia(Contrasena))
                throw new UsuarioException("Contraseña debe tener al menos 6 caracteres e incluir minúscula, mayúscula y número.");
        }

        private bool ValidacionesContrasenia(string contrasena)
        {
            bool mayus = Regex.IsMatch(contrasena, @"[A-ZÑ]");
            bool minus = Regex.IsMatch(contrasena, @"[a-zñ]");
            bool num   = Regex.IsMatch(contrasena, @"\d");

            if (mayus && minus && num && contrasena.Length >= 6)
                return true;

            return false;
        }
    }
}
