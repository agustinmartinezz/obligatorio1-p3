using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    public class CostoException:Exception
    {

        public CostoException(string mensaje) : base(mensaje)
        {
        }
        public CostoException() : base() { }

    }
}
