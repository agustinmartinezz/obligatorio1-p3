using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    [Index("TextoMail", IsUnique = true)]
    public class Mail : IValidar
    {
        public string TextoMail { get; }

        public Mail(string textoMail) { 
            this.TextoMail = textoMail;
            //ValidarDatos();
        }

        private Mail() { }

        public void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(TextoMail))
                throw new MailException("El mail no puede ser nulo o vacio.");

            if (!Regex.IsMatch(TextoMail, @"^[\w\.-]+@[\w\.-]+\.\w+$"))
                throw new MailException("El mail ingresado no es valido, verifique formato.");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Mail mail = (Mail) obj;
            return TextoMail.Equals(mail.TextoMail);
        }
    }
}
