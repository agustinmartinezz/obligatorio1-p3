﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    public class UsuarioException : Exception
    {
        public UsuarioException() :base() { }

        public UsuarioException(string mensaje) : base(mensaje) { }
    }
}
