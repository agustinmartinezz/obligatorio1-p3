using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    public class NombreTipoCabania : Nombre
    {
        public NombreTipoCabania(string textoNombre) : base(textoNombre)
        {
            //ValidarDatos();
        }
        
        public new void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(TextoNombre))
            {
                throw new NombreException("El nombre no puede estar vacio.");
            }
            if (TextoNombre.StartsWith(" ") || TextoNombre.EndsWith(" "))
            {
                throw new NombreException("El nombre no puede comenzar ni terminar con espacios");
            }
            if (!Regex.IsMatch(TextoNombre, @"^[a-zA-ZñÑ ]+$"))
            {
                throw new NombreException("El nombre no puede tener caracteres no alfabéticos.");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            NombreTipoCabania nombre = (NombreTipoCabania) obj;
            return TextoNombre.Equals(nombre.TextoNombre);
        }
    }
}
