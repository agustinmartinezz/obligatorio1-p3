﻿using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    [Index("TextoNombre", IsUnique = true)]
    public class Nombre : IValidar
    {
        public string TextoNombre { get; }

        public Nombre(string textoNombre) {
            this.TextoNombre = textoNombre;
            ValidarDatos();
        }

        public Nombre() { }

        public void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(TextoNombre))
            {
                throw new NombreException("El nombre no puede estar vacio.");
            }
            if (TextoNombre.StartsWith(" ") || TextoNombre.EndsWith(" "))
            {
                throw new NombreException("El nombre no puede comenzar ni terminar con espacios");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return TextoNombre.Equals(obj.ToString());
        }
    }
}
