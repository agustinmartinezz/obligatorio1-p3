using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioCabania: IRepositorio<Cabania>
    {
        void AddPicture(int cabaniaId, string name);
        IEnumerable<Cabania> FindByName(string nombre);
        IEnumerable<Cabania> FindByTipo(int tipoId);
        IEnumerable<Cabania> FindByMaxPeople(int maxPeople);
        IEnumerable<Cabania> FindHabilitadas();
    }
}
