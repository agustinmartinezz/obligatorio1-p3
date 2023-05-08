using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class TipoCabana:IValidar
    {
        private static int ultimoId = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CostoxHuesped { get; set; }
        public TipoCabana() 
        {
            Nombre = string.Empty;
            Descripcion = string.Empty;
            CostoxHuesped = 0;
        }
        public TipoCabana(string nombre, string descripcion, int costoxHuesped)
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

            if (string.IsNullOrWhiteSpace(Descripcion))
                throw new DescripcionException("La descripcion no puede estar vacia.");

            if (Descripcion.Length < Parametros.MinDescTipoCabana)
                throw new DescripcionException("La descripcion no puede tener menos de" + Parametros.MinDescTipoCabana.ToString() + " caracteres");

            if (Descripcion.Length < Parametros.MinDescTipoCabana)
                throw new DescripcionException("La descripcion no puede tener mas de " + Parametros.MaxDescTipoCabana.ToString() + " caracteres");

            if (CostoxHuesped <= 0)
                throw new DescripcionException("El costo debe ser mayor que 0");
        }
    }
}
