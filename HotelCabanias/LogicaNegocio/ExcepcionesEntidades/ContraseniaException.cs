using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    internal class ContraseniaException : Exception
    {
        public ContraseniaException(string mensaje) : base(mensaje)
        {
        }
        public ContraseniaException() : base() { }
    }
}
