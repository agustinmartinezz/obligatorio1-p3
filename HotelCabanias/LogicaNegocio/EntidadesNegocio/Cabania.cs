using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObjects;
using System.Xml.Linq;

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
        [NotMapped]
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
            //Nombre = new Nombre(string.Empty);
            //Descripcion = "";
           // Foto = "";
            Fotos = new List<string>();
           // Tipo = new TipoCabania();
        }

        public void ValidarDatos()
        {
            Nombre.ValidarDatos();

            if (Descripcion.Length > Parametros.MaxDescCabania || Descripcion.Length < Parametros.MinDescCabania)
            {
                throw new DescripcionException("La descripcion debe estar entre " + Parametros.MinDescCabania + " y " + Parametros.MaxDescCabania + " caracteres.");
            }
            //if (Fotos.Count <= 0 || Fotos == null)
            if (Foto == null || String.IsNullOrEmpty(Foto))
            {
                throw new FotoException("La Cabaña debe tener al menos una foto.");
            }
        }

        public string GetNombreFoto()
        {
            string name = this.Nombre.TextoNombre.ToLower().Replace(" ", "_") + "_001";

            return name;
        }

        //public string GetNombreFoto(string name) 
        //{
        //    int length = Fotos.Count();
        //    int lastNumber = 0;
        //    string lastNumberStr = "";

        //    if (length > 0)
        //    {
        //        string lastName = Fotos[length - 1].Split('.')[0];
        //        lastNumber = Int32.Parse(lastName.Substring(length - 3, length - 1));
        //    }
        //    lastNumber++;
        //    lastNumberStr = string.Format("int", lastNumber);
        //    if (lastNumber < 100)
        //    {
        //        lastNumberStr = "00" + lastNumber;
        //        if (lastNumber < 10)
        //        {
        //            lastNumberStr = lastNumberStr.Substring(1, 2);
        //        }
        //    }

        //    name = "Imagenes/" + name + "_" + lastNumberStr;
        //    return name;
        //}
    }
}

