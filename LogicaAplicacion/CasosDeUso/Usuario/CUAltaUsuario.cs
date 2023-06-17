using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUAltaUsuario: ICUAltaUsuario
    {
    
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUAltaUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public DTOUsuario AltaUsuario(DTOUsuario dtoUsuario)
        {

            try
            {
                Usuario u = new Usuario(dtoUsuario.Nombre,  dtoUsuario.Mail,  dtoUsuario.Contrasenia);
                RepoUsuario.Add(u);
                dtoUsuario.Id = u.Id;
                return dtoUsuario;

            }
            catch
            {
                throw;
            }
            
        }
    }
}
