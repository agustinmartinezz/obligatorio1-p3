using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
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

        private static int ultimoId = 1;

        public Usuario(string nombre, string mail, string contrasena) {
            Id = ultimoId++;
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
                throw new UsuarioException("Contrasena no puede ser nulo o vacio.");
        }
    }
}
