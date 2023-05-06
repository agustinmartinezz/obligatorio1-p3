using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    internal class UsuarioExcepcion : Exception
    {
        public UsuarioExcepcion() :base() { }

        public UsuarioExcepcion(string mensaje) : base(mensaje) { }
    }
}
