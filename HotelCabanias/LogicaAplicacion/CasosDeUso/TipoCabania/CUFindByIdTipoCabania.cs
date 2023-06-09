﻿using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using DTOs;

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
                    Id = tc.Id,
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
