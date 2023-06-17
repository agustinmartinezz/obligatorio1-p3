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
    public class CUFindByIdTipoCabania: ICUFindByIdTipoCabania
    {
    
        public IRepositorioTipoCabania RepoTipoCabania { get; set; }

        public CUFindByIdTipoCabania(IRepositorioTipoCabania repoTipoCabania)
        {
            RepoTipoCabania = repoTipoCabania;
        }

        public DTOTipoCabania FindByIdTipoCabania(int usuarioId)
        {
            
            TipoCabania tc = RepoTipoCabania.FindById(usuarioId);

            if (tc != null)
            {
                DTOTipoCabania dtoTipoCabania =
                new DTOTipoCabania()
                {
                    Nombre = tc.Nombre.TextoNombre,
                    Descripcion = tc.Descripcion,
                    CostoxHuesped = tc.CostoxHuesped.ValorCosto,
                };

                return dtoTipoCabania;
            }
            else
            {
                throw new Exception("El id no es correcto");
            }
          
        }

    }
}
