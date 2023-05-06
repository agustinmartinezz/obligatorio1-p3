using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    public class DescripcionException:Exception
    {

        public DescripcionException(string mensaje) : base(mensaje)
        {
        }
        public DescripcionException() : base() { }

    }
}
