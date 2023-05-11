using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class TipoCabania:IValidar
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CostoxHuesped { get; set; }
        public TipoCabania() 
        {
            Nombre = string.Empty;
            Descripcion = string.Empty;
            CostoxHuesped = 0;
        }
        public TipoCabania(string nombre, string descripcion, int costoxHuesped)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CostoxHuesped = costoxHuesped;
        }

        public void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new NombreException("El nombre del tipo de cabaña no puede estar vacio.");

            if (Nombre.StartsWith(" ") || Nombre.EndsWith(" "))
                throw new NombreException("El nombre no puede comenzar ni terminar con espacios.");

            if (!Regex.IsMatch(Nombre, @"^[a-zA-ZñÑ ]+$"))
                throw new DescripcionException("El nombre no puede tener caracteres no alfabéticos.");

            if (string.IsNullOrWhiteSpace(Descripcion))
                throw new DescripcionException("La descripcion no puede estar vacia.");

            if (Descripcion.Length < Parametros.MinDescTipoCabania)
                throw new DescripcionException("La descripcion no puede tener menos de" + Parametros.MinDescTipoCabania.ToString() + " caracteres");

            if (Descripcion.Length > Parametros.MaxDescTipoCabania)
                throw new DescripcionException("La descripcion no puede tener mas de " + Parametros.MaxDescTipoCabania.ToString() + " caracteres");

            if (CostoxHuesped <= 0)
                throw new DescripcionException("El costo debe ser mayor que 0");
        }
    }
}
