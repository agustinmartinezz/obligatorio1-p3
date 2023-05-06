using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioMantenimiento: IRepositorio<Mantenimiento>
    {
        IEnumerable<Mantenimiento> FindByDates(int CabanaId, DateTime date1,DateTime date2);
    }
}

