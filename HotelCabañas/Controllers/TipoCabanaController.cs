using HotelCabañas.Models;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;

namespace HotelCabañas.Controllers
{
    public class TipoCabanaController : Controller
    {
        IRepositorioTipoCabana repositorioTipoCabana { get; set; }

        public TipoCabanaController(IRepositorioTipoCabana repoTipoCabana) {
            repositorioTipoCabana = repoTipoCabana;
        }

        public IActionResult Index()
        {
            VMTiposCabana vmTipos = new();
            vmTipos.TiposCabana = repositorioTipoCabana.FindAll();

            return View(vmTipos);
        }

        [HttpPost]
        public IActionResult Index(string strSearch)
        {
            VMTiposCabana vmTipos = new();
            vmTipos.TiposCabana = repositorioTipoCabana.FindByName(strSearch);

            return View(strSearch);
        }
        
    }
}
