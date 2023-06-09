﻿using HotelCabañas.Filters;
using HotelCabañas.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading;

namespace HotelCabañas.Controllers
{
    public class MantenimientoController : Controller

    {
        private const string baseURL = "http://localhost:5256/api";

        // GET: MantenimientoController
        [Logueado]
        public ActionResult Index(int idCabania)
        {
            VMIndexMantenimiento vmIndexMantenimiento = new();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseURL + "/Cabania/Id/" + idCabania);

            httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            Task<HttpResponseMessage> getCabania = httpClient.GetAsync(httpClient.BaseAddress);
            
            getCabania.Wait();

            if (getCabania.Result.IsSuccessStatusCode)
            {
                HttpContent contenido = getCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                deseralize.Wait();

                vmIndexMantenimiento.Cabania = JsonConvert.DeserializeObject<VMCabania>(deseralize.Result);
                vmIndexMantenimiento.Busqueda.Fecha1 = DateTime.Now.AddMonths(-1);
                vmIndexMantenimiento.Busqueda.Fecha2 = DateTime.Now;
            }
            else 
            {
                HttpContent contenido = getCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();
                ViewBag.Error = deseralize.Result;
            }


            return View(vmIndexMantenimiento);
        }

        [Logueado]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VMIndexMantenimiento vmIndexMantenimiento)
        {
            try
            {
                //Si las fechas de busqueda son validas
                if (vmIndexMantenimiento.Busqueda.Fecha1 <= vmIndexMantenimiento.Busqueda.Fecha2)
                {
                    int idCabania = vmIndexMantenimiento.Cabania.Id;

                    HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri(baseURL + "/Cabania/Id/" + idCabania);

                    httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                    //Busco la cabania
                    Task<HttpResponseMessage> getCabania = httpClient.GetAsync(httpClient.BaseAddress);
                   
                    getCabania.Wait();

                    //Si obtuve la cabania correctamente
                    if (getCabania.Result.IsSuccessStatusCode)
                    {
                        HttpContent contenido = getCabania.Result.Content;
                        Task<string> deseralize = contenido.ReadAsStringAsync();

                        deseralize.Wait();
                        vmIndexMantenimiento.Cabania = JsonConvert.DeserializeObject<VMCabania>(deseralize.Result);

                        //Busco los mantenimientos de la misma entre las fechas dadas

                        DateTime fechaDesde = vmIndexMantenimiento.Busqueda.Fecha1;
                        string fechaDesdeFormateada = fechaDesde.ToString("yyyy-MM-dd");
                        DateTime fechaHasta = vmIndexMantenimiento.Busqueda.Fecha2;
                        string fechaHastaFormateada = fechaHasta.ToString("yyyy-MM-dd");

                        string URLParams = "cabaniaId=" + idCabania + "&fechaDesde="+fechaDesdeFormateada+"&fechaHasta="+fechaHastaFormateada;

                        HttpClient httpClientDates = new HttpClient();

                        httpClientDates.BaseAddress = new Uri(baseURL + "/Mantenimiento/Dates/" + URLParams);

                        httpClientDates.DefaultRequestHeaders.Authorization =
                           new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                        Task<HttpResponseMessage> getMantenimientos = httpClientDates.GetAsync(httpClientDates.BaseAddress);

                        getMantenimientos.Wait();

                        if (getMantenimientos.Result.IsSuccessStatusCode)
                        {
                            HttpContent contenido2 = getMantenimientos.Result.Content;
                            Task<string> deseralize2 = contenido2.ReadAsStringAsync();
                            deseralize2.Wait();
                            vmIndexMantenimiento.Mantenimientos = JsonConvert.DeserializeObject<IEnumerable<VMMantenimiento>>(deseralize2.Result);
                        } else
                        {
                            HttpContent contenido2 = getMantenimientos.Result.Content;
                            Task<string> deseralize2 = contenido2.ReadAsStringAsync();
                            ViewBag.Error = deseralize.Result;
                        }

                    }
                    else
                    {
                        HttpContent contenido = getCabania.Result.Content;
                        Task<string> deseralize = contenido.ReadAsStringAsync();
                        ViewBag.Error = deseralize.Result;
                    }

                    if (!vmIndexMantenimiento.Mantenimientos.Any())
                    {
                        ViewBag.Error = "No se encontraron mantenimientos para las fechas dadas.";
                    }
                }
                else
                {
                    ViewBag.Error = "La fecha desde debe ser menor o igual a la fecha hasta";
                }
            } catch (Exception e)
            {
                ViewBag.Error = e;
            }

            return View(vmIndexMantenimiento);
        }

        // GET: MantenimientoController/Create
        [Logueado]
        public ActionResult Create(int idCabania)
        {
            VMIndexMantenimiento vmMantenimiento = new VMIndexMantenimiento();
            vmMantenimiento.Mantenimiento.Fecha = new DateTime();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseURL + "/Cabania/Id/" + idCabania);

            httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            //Busco la cabania
            Task<HttpResponseMessage> getCabania = httpClient.GetAsync(httpClient.BaseAddress);
            
            getCabania.Wait();

            //Si obtuve la cabania correctamente
            if (getCabania.Result.IsSuccessStatusCode)
            {
                HttpContent contenido = getCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                deseralize.Wait();
                vmMantenimiento.Cabania = JsonConvert.DeserializeObject<VMCabania>(deseralize.Result);
            }
            else
            {
                HttpContent contenido = getCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();
                ViewBag.Error = deseralize.Result;
            }

            return View(vmMantenimiento);
        }

        // POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Logueado]
        public ActionResult Create(VMIndexMantenimiento vmIndexMantenimiento)
        {
            try
            {
                if (ModelState.IsValid) {
                    VMMantenimiento mantenimiento = new()
                    {
                        CabaniaId = vmIndexMantenimiento.Cabania.Id,
                        Fecha = vmIndexMantenimiento.Mantenimiento.Fecha,
                        Descripcion = vmIndexMantenimiento.Mantenimiento.Descripcion,
                        NombreRealizo = vmIndexMantenimiento.Mantenimiento.NombreRealizo,
                        Costo = vmIndexMantenimiento.Mantenimiento.Costo
                    };

                    HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri(baseURL + "/Mantenimiento");

                    httpClient.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                    Task<HttpResponseMessage> postMantenimiento = httpClient.PostAsJsonAsync(httpClient.BaseAddress, mantenimiento);

                    postMantenimiento.Wait();

                    if (postMantenimiento.Result.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Mantenimiento ingresado con exito.";
                        return RedirectToAction("Index", "Cabania");
                    }
                    else
                    {
                        HttpContent contenido = postMantenimiento.Result.Content;
                        Task<string> tarea2 = contenido.ReadAsStringAsync();

                        ViewBag.Error = tarea2.Result;
                    }
                } else
                {
                    ViewBag.Error = "Ingrese todos los datos.";
                }

                HttpClient httpClientAux = new HttpClient();
                httpClientAux.BaseAddress = new Uri(baseURL + "/Cabania/Id/" + vmIndexMantenimiento.Cabania.Id);

                httpClientAux.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> getCabania = httpClientAux.GetAsync(httpClientAux.BaseAddress);

                getCabania.Wait();

                if (getCabania.Result.IsSuccessStatusCode)
                {
                    HttpContent contenido = getCabania.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();

                    deseralize.Wait();

                    vmIndexMantenimiento.Cabania = JsonConvert.DeserializeObject<VMCabania>(deseralize.Result);
                }
                else
                {
                    HttpContent contenido = getCabania.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();
                    ViewBag.Error = deseralize.Result;

                    //Error no controlado, mando a index.
                    return View("~/Views/Home/Index.cshtml");
                }

                return View(vmIndexMantenimiento);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(vmIndexMantenimiento);
            }
        }
    }
}
