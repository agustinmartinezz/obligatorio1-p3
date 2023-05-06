using LogicaAccesoDatos.BaseDatos;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    internal class RepositorioTiposCabana : IRepositorioTipoCabana
    {
        public HotelCabanaContext Contexto { get; set; }

        public RepositorioTiposCabana(HotelCabanaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Cabana t)
        {
            throw new NotImplementedException();
        }

        public Cabana FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Cabana t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabana> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabana> FindByName(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
