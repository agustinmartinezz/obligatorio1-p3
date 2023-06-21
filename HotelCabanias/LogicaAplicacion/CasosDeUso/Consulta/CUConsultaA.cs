using LogicaAplicacion.InterfacesCasoDeUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Consulta
{
    public class CUConsultaA : ICUConsultaA
    {
        public IRepositorioConsulta RepositorioConsulta { get; set; }

        public CUConsultaA(IRepositorioConsulta repositorioConsulta)
        {
            RepositorioConsulta = repositorioConsulta;
        }


        public IEnumerable<object> ConsultaA(int idTipo, int monto)
        {
            try
            {
                return RepositorioConsulta.ConsultaA(idTipo, monto);
            }
            catch {
                throw;
            }
        }
    }
}
