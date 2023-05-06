using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAccesoDatos.BaseDatos;
using LogicaNegocio;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioMantenimiento:IRepositorioMantenimiento
    {
        public HotelCabanaContext Contexto { get; set; }

        public RepositorioMantenimiento(HotelCabanaContext contexto)
        {
            Contexto = contexto;
        }


        private static List<Mantenimiento> Mantenimientos = new List<Mantenimiento>();
        public void Add(Mantenimiento c)
        {
            try
            {
                c.ValidarDatos();
                Mantenimientos.Add(c);
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
                Mantenimientos.Remove(mantenimiento);
            }

        }

        public Mantenimiento FindById(int id)
        {
            Mantenimiento mantenimiento = null;
            int i = 0;
            while (i < Mantenimientos.Count && mantenimiento == null)
            {
                if (Mantenimientos[i].Id == id)
                {
                    mantenimiento = Mantenimientos[i];
                }
                i++;
            }
            return mantenimiento;

        }

        public IEnumerable<Mantenimiento> FindAll()
        {
            // throw new NotImplementedException();
            return Mantenimientos;
        }

        public void Update(int id, Mantenimiento mantenimiento)
        {

            Mantenimiento mantenimientoBuscado = FindById(id);
            if (mantenimientoBuscado != null)
            {
            //    mantenimientoBuscado.RUT = mantenimiento.RUT;
            //    mantenimientoBuscado.RazonSocial = mantenimiento.RazonSocial;
            }


        }

        public IEnumerable<Mantenimiento> FindByDates(int CabanaId,DateTime date1, DateTime date2)
        {
           return Contexto.Mantenimientos
                .Where(m => m.Fecha >= date1)
                .Where(m => m.Fecha <= date2)
                .Where(m => m.CabanaId >= CabanaId)
                .ToList();

        }
    }
}
