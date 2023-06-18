using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
   

    public class Nombre : IValidar
    {
        public string TextoNombre { get; }

        public Nombre(string textoNombre) {
            this.TextoNombre = textoNombre;
            //ValidarDatos();
        }

        public void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(TextoNombre))
            {
                throw new NombreException("El nombre no puede estar vacio.");
            }
            if (TextoNombre.StartsWith(" ") || TextoNombre.EndsWith(" "))
            {
                throw new NombreException("El nombre no puede comenzar ni terminar con espacios");
            }
        }
    }
}
