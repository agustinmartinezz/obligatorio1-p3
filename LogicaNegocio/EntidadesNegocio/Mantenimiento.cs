using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LogicaNegocio.InterfacesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Mantenimiento:IValidar
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Costo { get; set; }
        public string NombreReazlizo { get; set; }
        public Cabana Cabana { get; set; }

        [Key,ForeignKey(nameof(Cabana))]
        public int CabanaId { get; set; }

        public void ValidarDatos()
        {
            ((IValidar)Cabana).ValidarDatos();
        }
    }
}
