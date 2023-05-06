using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario:IValidar
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Contrasena { get; set; }

        public void ValidarDatos()
        {
            throw new NotImplementedException();
        }
    }
}
