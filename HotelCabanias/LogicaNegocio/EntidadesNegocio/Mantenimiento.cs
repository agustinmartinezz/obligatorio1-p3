using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObjects;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Mantenimiento:IValidar
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public Costo Costo { get; set; }
        [Required]
        public Nombre NombreRealizo { get; set; }
        [ForeignKey(nameof(Cabania))]
        public int CabaniaId { get; set; }
        public Cabania Cabania { get; set; }
        
        public Mantenimiento() {
            Descripcion = "";
            Costo = new Costo(0);
            NombreRealizo = new Nombre(string.Empty);
            Cabania = new Cabania();
        }

        public void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(Descripcion))
            {
                throw new DescripcionException("La descripcion no puede estar vacia.");
            }

            if (Descripcion.Length > Parametros.MaxDescMantenimiento || Descripcion.Length < Parametros.MinDescMantenimiento)
            {
                throw new DescripcionException("La descripcion debe estar entre 10 y 200 caracteres.");
            }

            NombreRealizo.ValidarDatos();

            Costo.ValidarDatos();
        }
    }
}

