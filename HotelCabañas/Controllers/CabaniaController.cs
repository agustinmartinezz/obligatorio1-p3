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
    public class CabaniaController : Controller
    {
        public IRepositorioCabania repositorioCabania { get; set; }
        public IRepositorioTipoCabania repositorioTipoCabania { get; set; }
      

        public CabaniaController(IRepositorioCabania repoCabania,IRepositorioTipoCabania repoTipoCabania)
        {
            repositorioCabania = repoCabania;
            repositorioTipoCabania = repoTipoCabania;
        }

        // GET: CabaniaController

        [HttpGet]
        public ActionResult Index()
        {
            VMCabania vmCabania = new VMCabania();
            vmCabania.Cabanias = repositorioCabania.FindAll();
            return View(vmCabania);
        }

        [HttpPost]
        public ActionResult Index(VMCabania vmCabania)
        {
            string? searchText = vmCabania.strSearchCabania;
            int intSearch = Int32.Parse(searchText);

            switch (vmCabania.searchTypeCabania)
            {
                case 1:
                    vmCabania.Cabanias = repositorioCabania.FindByName(searchText);
                    break;
                case 2:
                    vmCabania.Cabanias = repositorioCabania.FindByTypo(intSearch);
                    break;
                case 3:
                    vmCabania.Cabanias = repositorioCabania.FindByMaxPeople(intSearch);
                    break;
                case 4:
                    vmCabania.Cabanias = repositorioCabania.FindHabilitadas();
                    break;

            }

            return View(vmCabania.Cabanias);
        }

        // GET: CabaniaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CabaniaController/Create
        [HttpGet]
        public ActionResult Create()
        {
            VMCabania vmCabania = new VMCabania();
            vmCabania.Tipos = repositorioTipoCabania.FindAll();
            return View(vmCabania);
        }

        // POST: CabaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Id,VMCabania vmCabania)
        {
            try
            {
                Cabania c = vmCabania.Cabania;
                repositorioCabania.Add(c); 
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Mensaje = e.Message;
                vmCabania.Tipos = repositorioTipoCabania.FindAll();
                return View(vmCabania);
            }
        }

        // GET: CabaniaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CabaniaController/Edit/5
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

        // GET: CabaniaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CabaniaController/Delete/5
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
