using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    public class NombreException:Exception
    {

        public NombreException(string mensaje) : base(mensaje)
        {
        }
        public NombreException() : base() { }

    }
}
