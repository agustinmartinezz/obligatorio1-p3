using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ExcepcionesEntidades;


namespace LogicaNegocio.EntidadesNegocio
{
    public class Cabania: IValidar
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Tipo))]
        public int TipoId { get; set; }
        public TipoCabania Tipo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [MinLength(10, ErrorMessage = "La descripción debe tener mínimo 10 caracteres")]
        [MaxLength(500, ErrorMessage = "La descripción debe tener máximo 500 caracteres")]
        public string Descripcion { get; set; }
        public Boolean TieneJacuzzi { get; set; }
        public Boolean HabilitadaReservas { get; set; }
        public int NumeroHabitacion { get; set; }
        public static int UltimoNumHab { get; set; }

        public int MaxPersonas { get; set; }
        public string Foto { get; set; }

        public void ValidarDatos()
        {

            if (Nombre=="")
            {
              throw new NombreException("El nombre de una Cabaña no puede estar vacio");
            }
            if (Nombre[0].Equals(" ") || Nombre[Nombre.Length-1].Equals(" "))
            {
                throw new NombreException("El nombre no puede comenzar ni terminar con espacios");
            }
            if (Descripcion.Length>500 || Descripcion.Length < 10)
            {
                throw new DescripcionException("La descripcion debe estar entre 10 y 500 caracteres");
            }

        }
    }
}

