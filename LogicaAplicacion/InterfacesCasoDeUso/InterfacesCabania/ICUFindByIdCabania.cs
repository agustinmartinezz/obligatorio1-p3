using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasoDeUso
{
    public interface ICUFindByIdCabania
    {
        public DTOCabania FindByIdCabania(int cabaniaId);
    }
}
