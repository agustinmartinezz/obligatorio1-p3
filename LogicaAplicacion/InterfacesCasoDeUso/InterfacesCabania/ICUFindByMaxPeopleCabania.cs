using DTOs;

namespace LogicaAplicacion.InterfacesCasoDeUso
{
    public interface ICUFindByMaxPeopleCabania
    { 
     public IEnumerable<DTOCabania> FindByMaxPeopleCabania(int max);

    }
}
