using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.LogicaNegocio.InterfacesRepositorios
{
    public  interface IRepositorio<T>
    {
        void Add(T t);
        T FindById(int id);
        void Delete(int id);
        void Update(int id,T t);
        IEnumerable<T> FindAll();



    }
}
