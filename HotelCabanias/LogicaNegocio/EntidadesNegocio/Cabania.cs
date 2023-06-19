using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObjects;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Cabania: IValidar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Tipo))]
        public int TipoId { get; set; }
        public TipoCabania Tipo { get; set; }
        [Required]
        public Nombre Nombre { get; set; }
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
        public  List<string> Fotos { get; set; }

        public Cabania(int tipoId, string nombre, string descripcion, bool tieneJacuzzi, bool habilitadaReservas, int maxPersonas)
        {
            UltimoNumHab++;
            TipoId = tipoId;
            Nombre = new Nombre(nombre);
            Descripcion = descripcion;
            TieneJacuzzi = tieneJacuzzi;
            HabilitadaReservas = habilitadaReservas;
            NumeroHabitacion = UltimoNumHab;
            MaxPersonas = maxPersonas;
            Fotos = new List<string>();
        }

        public Cabania()
        {
            Nombre = new Nombre(string.Empty);
            Descripcion = "";
            Foto = "";
            Fotos = new List<string>();
            Tipo = new();
        }

        public void ValidarDatos()
        {
            Nombre.ValidarDatos();

            if (Descripcion.Length > Parametros.MaxDescCabania || Descripcion.Length < Parametros.MinDescCabania)
            {
                throw new DescripcionException("La descripcion debe estar entre " + Parametros.MinDescCabania + " y " + Parametros.MaxDescCabania + " caracteres.");
            }
            if (Fotos.Count <= 0 || Fotos == null)
            {
                throw new FotoException("La Cabaña debe tener al menos una foto.");
            }
        }

        public string GetNombreFoto()
        {
            string nombre = Nombre.TextoNombre.Trim().Replace(" ", "_") + "_001";
            return nombre;
        }
    }
}

