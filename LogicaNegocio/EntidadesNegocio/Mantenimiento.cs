using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Mantenimiento:IValidar
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public int Costo { get; set; }

        public string NombreRealizo { get; set; }

        [ForeignKey(nameof(Cabania))]
        public int CabaniaId { get; set; }

        public Cabania Cabania { get; set; }
        
        public Mantenimiento() {
            Descripcion = "";
            NombreRealizo = "";
            Cabania = new Cabania();
        }

        public void ValidarDatos()
        {
            if (Descripcion.Length > Parametros.MaxDescMantenimiento || Descripcion.Length < Parametros.MinDescMantenimiento)
            {
                throw new DescripcionException("La descripcion debe estar entre 10 y 200 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(NombreRealizo))
            {
                throw new NombreException("El nombre no puede estar vacio.");
            }
        }
    }
}

