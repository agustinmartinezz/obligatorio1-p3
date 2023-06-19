using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    internal class MailException : Exception
    {
        public MailException(string mensaje) : base(mensaje)
        {
        }
        public MailException() : base() { }
    }
}
