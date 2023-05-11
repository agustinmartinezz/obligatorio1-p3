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
        [Required]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Tipo))]
        public int TipoId { get; set; }
        public TipoCabania Tipo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public Boolean TieneJacuzzi { get; set; }
        [Required]
        public Boolean HabilitadaReservas { get; set; }
        public int NumeroHabitacion { get; set; }
        public static int UltimoNumHab { get; set; }
        [Required]
        public int MaxPersonas { get; set; }
        [Required]
        public string Foto { get; set; }

        public Cabania(int tipoId, string nombre, string descripcion, bool tieneJacuzzi, bool habilitadaReservas, int maxPersonas, string foto)
        {
            UltimoNumHab++;
            TipoId = tipoId;
            Nombre = nombre;
            Descripcion = descripcion;
            TieneJacuzzi = tieneJacuzzi;
            HabilitadaReservas = habilitadaReservas;
            NumeroHabitacion = UltimoNumHab;
            MaxPersonas = maxPersonas;
            Foto = foto;
        }

        public Cabania()
        {
            Nombre = "";
            Descripcion = "";
            Foto = "";
            Tipo = new();
        }

        public void ValidarDatos()
        {

            if (string.IsNullOrWhiteSpace(Nombre))
            {
              throw new NombreException("El nombre de una Cabaña no puede estar vacio.");
            }
            if (Nombre.StartsWith(" ") || Nombre.EndsWith(" "))
            {
                throw new NombreException("El nombre no puede comenzar ni terminar con espacios");
            }
            if (Descripcion.Length>Parametros.MaxDescCabania || Descripcion.Length < Parametros.MinDescCabania)
            {
                throw new DescripcionException("La descripcion debe estar entre " + Parametros.MinDescCabania + " y " + Parametros.MaxDescCabania + " caracteres.");
            }
            if (string.IsNullOrWhiteSpace(Foto))
            {
                throw new FotoException("La Cabaña debe tener una foto.");
            }

        }

        public string GetNombreFoto()
        {
            string nombre = Nombre.Trim().Replace(" ", "_") + "_001";
            return nombre;
        }
    }
}

