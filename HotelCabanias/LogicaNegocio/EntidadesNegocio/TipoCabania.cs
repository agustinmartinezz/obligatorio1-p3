using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ValueObjects;
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
        public NombreTipoCabania Nombre { get; set; }
        public string Descripcion { get; set; }
        public Costo CostoxHuesped { get; set; }

        public TipoCabania(string nombre, string descripcion, int costoxHuesped)
        {
            Nombre = new NombreTipoCabania(nombre);
            Descripcion = descripcion;
            CostoxHuesped = new Costo(costoxHuesped);
        }

        public TipoCabania() {}

        public void ValidarDatos()
        {
            Nombre.ValidarDatos();

            if (string.IsNullOrWhiteSpace(Descripcion))
                throw new DescripcionException("La descripcion no puede estar vacia.");

            if (Descripcion.Length < Parametros.MinDescTipoCabania)
                throw new DescripcionException("La descripcion no puede tener menos de " + Parametros.MinDescTipoCabania.ToString() + " caracteres");

            if (Descripcion.Length > Parametros.MaxDescTipoCabania)
                throw new DescripcionException("La descripcion no puede tener mas de " + Parametros.MaxDescTipoCabania.ToString() + " caracteres");

            CostoxHuesped.ValidarDatos();
        }
    }
}
