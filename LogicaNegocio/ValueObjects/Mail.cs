using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    

    public class Mail : IValidar
    {
        public string TextoMail { get; }

        public Mail(string textoMail) { 
            this.TextoMail = textoMail;
            //ValidarDatos();
        }

        public void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(TextoMail))
                throw new MailException("El mail no puede ser nulo o vacio.");

            if (!Regex.IsMatch(TextoMail, @"^[\w\.-]+@[\w\.-]+\.\w+$"))
                throw new MailException("El mail ingresado no es valido, verifique formato.");
        }
    }
}
