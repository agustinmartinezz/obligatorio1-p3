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
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            VMTiposCabana vmTipoCabana = new()
            {
                TiposCabana = repositorioTipoCabana.FindAll()
            };

            if (!vmTipoCabana.TiposCabana.Any())
                TempData["Error"] = "No existen tipos de cabaña ingresados.";

            return View(vmTipoCabana);
        }

        [HttpPost]
        public IActionResult Index(VMTiposCabana vmTipoCabana)
        {
            string texto = vmTipoCabana.StrSearch;

            if (string.IsNullOrWhiteSpace(texto))
            {
                vmTipoCabana.TiposCabana = repositorioTipoCabana.FindAll();

                if (!vmTipoCabana.TiposCabana.Any())
                    TempData["Error"] = "No existen tipos de cabaña ingresados.";
            }
            else
            {
                vmTipoCabana.TiposCabana = repositorioTipoCabana.FindByName(texto);
                vmTipoCabana.StrSearch = texto;

                if (!vmTipoCabana.TiposCabana.Any())
                    TempData["Error"] = "No existen tipos de cabaña con ese nombre.";
            }
            
            return View(vmTipoCabana);
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
        public IActionResult Create(TipoCabana tipoCabana)
        {
            try
            {
                tipoCabana.ValidarDatos();

                repositorioTipoCabana.Add(tipoCabana);
                TempData["Mensaje"] = "Tipo de cabaña ingresado con éxito.";

                VMTiposCabana vmTipoCabana = new();
                return RedirectToAction("Index", vmTipoCabana);
            } catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
            
        }

        public IActionResult Edit(int id)
        {
            TipoCabana tipoCabana = repositorioTipoCabana.FindById(id);

            return View(tipoCabana);
        }

        [HttpPost]
        public IActionResult Edit(TipoCabana tipoCabana)
        {
            try
            {
                tipoCabana.ValidarDatos();

                repositorioTipoCabana.Update(tipoCabana.Id, tipoCabana);

                TempData["Mensaje"] = "Tipo de cabaña modificado correctamente.";
                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(tipoCabana);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                repositorioTipoCabana.Delete(id);

                TempData["Mensaje"] = "Tipo de cabaña eliminado correctamente.";

                VMTiposCabana vmTipoCabana = new();
                return RedirectToAction("Index", vmTipoCabana);
            } catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
    }
}
