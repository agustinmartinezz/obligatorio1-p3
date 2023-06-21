using HotelCabañas.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading;

namespace HotelCabañas.Controllers
{
    public class MantenimientoController : Controller

    {
        private const string baseURL = "http://localhost:5256/api";

        // GET: MantenimientoController
        public ActionResult Index(int idCabania)
        
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            VMIndexMantenimiento vmIndexMantenimiento = new();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseURL + "/Cabania/Id/" + idCabania);

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
                ViewBag.Mensaje = deseralize.Result;
            }


            return View(vmIndexMantenimiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VMIndexMantenimiento vmIndexMantenimiento)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            try
            {
                //Si las fechas de busqueda son validas
                if (vmIndexMantenimiento.Busqueda.Fecha1 <= vmIndexMantenimiento.Busqueda.Fecha2)
                {
                    int idCabania = vmIndexMantenimiento.Cabania.Id;

                    HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri(baseURL + "/Cabania/Id/" + idCabania);
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
                            ViewBag.Mensaje = deseralize.Result;
                        }

                    }
                    else
                    {
                        HttpContent contenido = getCabania.Result.Content;
                        Task<string> deseralize = contenido.ReadAsStringAsync();
                        ViewBag.Mensaje = deseralize.Result;
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
        public ActionResult Create(int idCabania)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            VMIndexMantenimiento vmMantenimiento = new VMIndexMantenimiento();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseURL + "/Cabania/Id/" + idCabania);

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
                ViewBag.Mensaje = deseralize.Result;
            }

            return View(vmMantenimiento);
        }

        // POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMIndexMantenimiento vmIndexMantenimiento)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            try
            {               
                VMMantenimiento mantenimiento = new ()
                {
                    CabaniaId = vmIndexMantenimiento.Cabania.Id,
                    Fecha = vmIndexMantenimiento.Mantenimiento.Fecha,
                    Descripcion = vmIndexMantenimiento.Mantenimiento.Descripcion,
                    NombreRealizo = vmIndexMantenimiento.Mantenimiento.NombreRealizo,
                    Costo = vmIndexMantenimiento.Mantenimiento.Costo
                };

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseURL + "/Mantenimiento");

                Task<HttpResponseMessage> postMantenimiento = httpClient.PostAsJsonAsync(httpClient.BaseAddress, mantenimiento);

                postMantenimiento.Wait();

                if (postMantenimiento.Result.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Mantenimiento ingresado con exito.";
                    return RedirectToAction("Index", "Cabania");
                } else
                {
                    HttpContent contenido = postMantenimiento.Result.Content;
                    Task<string> tarea2 = contenido.ReadAsStringAsync();

                    ViewBag.Error = tarea2.Result;
                    return View(vmIndexMantenimiento);
                }               
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(vmIndexMantenimiento);
            }
        }
    }
}
