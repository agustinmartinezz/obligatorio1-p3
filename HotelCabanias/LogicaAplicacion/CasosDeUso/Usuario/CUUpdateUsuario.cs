using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUUpdateUsuario : ICUUpdateUsuario
    {

        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUUpdateUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public DTOUsuario UpdateUsuario(int Id, DTOUsuario dtoUsuario)
        {
            try
            {
                Usuario usuario = new ()
                {
                    Nombre = new Nombre(dtoUsuario.Nombre),
                    Mail = new Mail(dtoUsuario.Mail),
                    Contrasenia = new Contrasenia(dtoUsuario.Contrasenia)
                };

                RepoUsuario.Update(Id,usuario);
                dtoUsuario.Id = usuario.Id;
            }
            catch
            {
                throw;
            }
            return dtoUsuario;
        }
    }
}
