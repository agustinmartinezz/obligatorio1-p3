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

        [MinLength(10, ErrorMessage = "La descripción debe tener mínimo 10 caracteres")]
        [MaxLength(200, ErrorMessage = "La descripción debe tener máximo 200 caracteres")]
        public string Descripcion { get; set; }

        public int Costo { get; set; }

        public string NombreRealizo { get; set; }

        [ForeignKey(nameof(Cabania))]
        public int CabaniaId { get; set; }

        public Cabania Cabania { get; set; }
        
        public Mantenimiento() {}

        public void ValidarDatos()
        {
            if (Descripcion.Length > 200 || Descripcion.Length < 10)
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
