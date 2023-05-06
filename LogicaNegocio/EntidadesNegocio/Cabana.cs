using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.InterfacesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Cabana: IValidar
    {
        [Key]
        public int Id { get; set; }

        [Key, ForeignKey(nameof(Tipo))]
        public int TipoId { get; set; }
        public TipoCabana Tipo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Boolean TieneJacuzzi { get; set; }
        public Boolean HabilitadaReservas { get; set; }
        public int NumeroHabitacion { get; set; }
        public static int UltimoNumHab { get; set; }

        public int MaxPersonas { get; set; }
        public string Foto { get; set; }

        public void ValidarDatos()
        {

            if (Nombre)
            {
              // throw new RUTException("El rut debe tener mas de 12 digitos");
            }
            if (Descripcion)
            {
                // throw new RUTException("El rut debe tener mas de 12 digitos");
            }
            if (Nombre)
            {
                // throw new RUTException("El rut debe tener mas de 12 digitos");
            }

        }
    }
}

