using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAccesoDatos.BaseDatos;
using LogicaNegocio;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesEntidades;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioMantenimiento
    {
        public HotelCabanaContext Contexto { get; set; }

        public RepositorioMantenimiento(HotelCabanaContext contexto)
        {
            Contexto = contexto;
        }


        private static List<Mantenimiento> mantenimientoes = new List<Mantenimiento>();
        public void Add(Mantenimiento c)
        {
            try
            {
                c.ValidarDatos();
                mantenimientoes.Add(c);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {

            Mantenimiento mantenimiento = FindById(id);
            if (mantenimiento != null)
            {
                mantenimientos.Remove(mantenimiento);
            }

        }

        public Mantenimiento FindById(int id)
        {
            Mantenimiento mantenimiento = null;
            int i = 0;
            while (i < mantenimientos.Count && mantenimientos == null)
            {
                if (mantenimientos[i].Id == id)
                {
                    mantenimiento = mantenimientoes[i];
                }
                i++;
            }
            return mantenimiento;

        }

        public IEnumerable<Mantenimiento> FindAll()
        {
            // throw new NotImplementedException();
            return mantenimientos;
        }

        public void Update(int id, Mantenimiento mantenimiento)
        {

            Mantenimiento mantenimientoBuscado = FindById(id);
            if (mantenimientoBuscado != null)
            {
                mantenimientoBuscado.RUT = mantenimiento.RUT;
                mantenimientoBuscado.RazonSocial = mantenimiento.RazonSocial;
            }


        }

    }
}
