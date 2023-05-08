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

        public Usuario LoguearUsuario(string mail, string contrasena)
        {

            try
            {
                Usuario usrEncontrado = Contexto.Usuarios.First(u => u.Mail == mail);

                if (usrEncontrado.Contrasena.Equals(contrasena))
                    return usrEncontrado;

                return null;

            }
            catch (Exception e)
            {
                return null;
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
            throw new NotImplementedException();
        }
    }
}
