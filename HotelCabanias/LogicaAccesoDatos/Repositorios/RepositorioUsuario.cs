using LogicaAccesoDatos.BaseDatos;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public HotelCabaniaContext Contexto { get; set; }

        public RepositorioUsuario(HotelCabaniaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Usuario usuario)
        {
            try {
                usuario.ValidarDatos();

                Contexto.Usuarios.Add(usuario);
                Contexto.SaveChanges();
            } catch (Exception e)
            {
                throw new UsuarioException(e.Message);
            }
        }

        public Usuario LoguearUsuario(string mail, string contrasenia)
        {
            try
            {
                Usuario usrEncontrado = Contexto.Usuarios.FirstOrDefault(u => u.Mail.TextoMail == mail);

                if (usrEncontrado == null)
                    return null;

                if (usrEncontrado.Contrasenia.Equals(contrasenia))
                    return usrEncontrado;
                else
                    return null;
            }
            catch
            {
                throw;
            }
        }

        public void Update(int id, Usuario usuario)
        {
            throw new NotImplementedException();
        }


        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios;
        }
    }
}
