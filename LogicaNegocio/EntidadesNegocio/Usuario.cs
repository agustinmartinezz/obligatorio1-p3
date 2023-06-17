using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ValueObjects;
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
        public Nombre Nombre { get; set; }

        public Mail Mail { get; set; }

        public Contrasenia Contrasenia { get; set; }

        public Usuario() { }

        public Usuario(string nombre, string mail, string contrasenia) {
            Nombre = new Nombre(nombre);
            Mail = new Mail(mail);
            Contrasenia = new Contrasenia(contrasenia);
        }

        public void ValidarDatos()
        {
            Nombre.ValidarDatos();

            Mail.ValidarDatos();

            Contrasenia.ValidarDatos();
        }
    }
}
