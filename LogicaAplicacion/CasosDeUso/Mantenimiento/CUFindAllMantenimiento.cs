﻿using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUFindAllMantenimiento : ICUFindAllMantenimiento
    {

        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public CUFindAllMantenimiento(IRepositorioMantenimiento repoMantenimiento)
        {
            RepoMantenimiento = repoMantenimiento;
        }

        public void FindAllMantenimiento()
        {
            try
            {
                RepoMantenimiento.FindAll();
            }
            catch
            {
                throw;
            }
        }
    }
}