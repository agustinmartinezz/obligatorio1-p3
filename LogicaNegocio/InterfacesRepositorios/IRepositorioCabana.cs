using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioCabana: IRepositorio<Cabana>
    {
        IEnumerable<Cabana> FindByName(string nombre);
        IEnumerable<Cabana> FindByTypo(int tipoId);
        IEnumerable<Cabana> FindByMaxPeople(int maxPeople);
        IEnumerable<Cabana> FindHabilitadas();
    }
}
