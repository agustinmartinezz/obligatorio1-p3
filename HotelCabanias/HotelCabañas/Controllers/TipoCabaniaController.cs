using HotelCabañas.Models;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;

namespace HotelCabañas.Controllers
{
    public class TipoCabaniaController : Controller
    {
        IRepositorioTipoCabania repositorioTipoCabania { get; set; }

        public TipoCabaniaController(IRepositorioTipoCabania repoTipoCabania) {
            repositorioTipoCabania = repoTipoCabania;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            VMTiposCabania vmTipoCabania = new()
            {
                TiposCabania = repositorioTipoCabania.FindAll()
            };

            if (!vmTipoCabania.TiposCabania.Any())
                TempData["Error"] = "No existen tipos de cabaña ingresados.";

            return View(vmTipoCabania);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(VMTiposCabania vmTipoCabania)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            string texto = vmTipoCabania.StrSearch;

            if (string.IsNullOrWhiteSpace(texto))
            {
                vmTipoCabania.TiposCabania = repositorioTipoCabania.FindAll();

                if (!vmTipoCabania.TiposCabania.Any())
                    TempData["Error"] = "No existen tipos de cabaña ingresados.";
            }
            else
            {
                vmTipoCabania.TiposCabania = repositorioTipoCabania.FindByName(texto);
                vmTipoCabania.StrSearch = texto;

                if (!vmTipoCabania.TiposCabania.Any())
                    TempData["Error"] = "No existen tipos de cabaña con ese nombre.";
            }
            
            return View(vmTipoCabania);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoCabania tipoCabania)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            try
            {
                repositorioTipoCabania.Add(tipoCabania);
                TempData["Mensaje"] = "Tipo de cabaña ingresado con éxito.";

                VMTiposCabania vmTipoCabania = new();
                return RedirectToAction("Index", vmTipoCabania);
            } catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
            
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            TipoCabania tipoCabania = repositorioTipoCabania.FindById(id);

            return View(tipoCabania);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TipoCabania tipoCabania)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            try
            {
                tipoCabania.ValidarDatos();

                repositorioTipoCabania.Update(tipoCabania.Id, tipoCabania);

                TempData["Mensaje"] = "Tipo de cabaña modificado correctamente.";
                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(tipoCabania);
            }
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            try
            {
                repositorioTipoCabania.Delete(id);

                TempData["Mensaje"] = "Tipo de cabaña eliminado correctamente.";

                VMTiposCabania vmTipoCabania = new();
                return RedirectToAction("Index", vmTipoCabania);
            } catch (Exception e)
            {
                TempData["Error"] = e.Message;
                
                VMTiposCabania vmTipoCabania = new();

                return RedirectToAction("Index", vmTipoCabania);
            }
        }
    }
}
