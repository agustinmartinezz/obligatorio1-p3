using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Consulta
{
    public class CUConsultaB : ICUConsultaB
    {
        public IRepositorioConsulta RepositorioConsulta { get; set; }

        public CUConsultaB(IRepositorioConsulta repositorioConsulta)
        {
            RepositorioConsulta = repositorioConsulta;
        }

        public IEnumerable<object> ConsultaB(int desde, int hasta)
        {
            try
            {
                return RepositorioConsulta.ConsultaB(desde, hasta);
            }
            catch
            {
                throw;
            }
        }
    }
}
