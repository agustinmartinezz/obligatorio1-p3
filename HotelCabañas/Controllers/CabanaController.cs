using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using HotelCabañas.Models;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelCabañas.Controllers
{
    public class CabanaController : Controller
    {
        public IRepositorioCabana repositorioCabana { get; set; }
        public IRepositorioTipoCabana repositorioTipoCabana { get; set; }
      

        public CabanaController(IRepositorioCabana repoCabana,IRepositorioTipoCabana repoTipoCabana)
        {
            repositorioCabana = repoCabana;
            repositorioTipoCabana = repoTipoCabana;
        }

        // GET: CabanaController

        [HttpGet]
        public ActionResult Index()
        {
            VMCabana vmCabana = new VMCabana();
            vmCabana.Cabanas = repositorioCabana.FindAll();
            return View(vmCabana);
        }

        [HttpPost]
        public ActionResult Index(VMCabana vmCabana)
        {
            string? searchText = vmCabana.strSearchCabana;
            int intSearch = Int32.Parse(searchText);

            switch (vmCabana.searchTypeCabana)
            {
                case 1:
                    vmCabana.Cabanas = repositorioCabana.FindByName(searchText);
                    break;
                case 2:
                    vmCabana.Cabanas = repositorioCabana.FindByTypo(intSearch);
                    break;
                case 3:
                    vmCabana.Cabanas = repositorioCabana.FindByMaxPeople(intSearch);
                    break;
                case 4:
                    vmCabana.Cabanas = repositorioCabana.FindHabilitadas();
                    break;

            }

            return View(vmCabana.Cabanas);
        }

        // GET: CabanaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CabanaController/Create
        [HttpGet]
        public ActionResult Create()
        {
            VMCabana vmCabana = new VMCabana();
            vmCabana.Tipos = repositorioTipoCabana.FindAll();
            return View(vmCabana);
        }

        // POST: CabanaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Id,VMCabana vmCabana)
        {
            try
            {
                Cabana c = vmCabana.Cabana;
                repositorioCabana.Add(c); 
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Mensaje = e.Message;
                vmCabana.Tipos = repositorioTipoCabana.FindAll();
                return View(vmCabana);
            }
        }

        // GET: CabanaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CabanaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CabanaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CabanaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
