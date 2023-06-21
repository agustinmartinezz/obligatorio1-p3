using HotelCabañas.Filters;
using HotelCabañas.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HotelCabañas.Controllers
{
    public class TipoCabaniaController : Controller
    {
        private const string baseURL = "http://localhost:5256/api";

        [Logueado]
        public IActionResult Index()
        {
            VMIndexTipoCabania vmIndexTipoCabania = new ();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseURL + "/TipoCabania");

            httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            Task<HttpResponseMessage> getTiposCabania = httpClient.GetAsync(httpClient.BaseAddress);

            getTiposCabania.Wait();

            if (getTiposCabania.Result.IsSuccessStatusCode)
            {
                HttpContent contenido = getTiposCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                deseralize.Wait();

                vmIndexTipoCabania.TiposCabania = JsonConvert.DeserializeObject<IEnumerable<VMTipoCabania>>(deseralize.Result);               
            } else
            {
                HttpContent contenido = getTiposCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();
                ViewBag.Mensaje = deseralize.Result;
            }

            if (!vmIndexTipoCabania.TiposCabania.Any())
                TempData["Error"] = "No existen tipos de cabaña ingresados.";

            return View(vmIndexTipoCabania);
        }

        [Logueado]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(VMIndexTipoCabania vmIndexTipoCabania)
        {
            string texto = vmIndexTipoCabania.Busqueda.SearchText;

            if (string.IsNullOrWhiteSpace(texto))
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseURL + "/TipoCabania");

                httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> getTiposCabania = httpClient.GetAsync(httpClient.BaseAddress);

                getTiposCabania.Wait();

                if (getTiposCabania.Result.IsSuccessStatusCode)
                {
                    HttpContent contenido = getTiposCabania.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();

                    deseralize.Wait();

                    vmIndexTipoCabania.TiposCabania = JsonConvert.DeserializeObject<IEnumerable<VMTipoCabania>>(deseralize.Result);
                }
                else
                {
                    HttpContent contenido = getTiposCabania.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();
                    ViewBag.Mensaje = deseralize.Result;
                }

                if (!vmIndexTipoCabania.TiposCabania.Any())
                    TempData["Error"] = "No existen tipos de cabaña ingresados.";
            }
            else
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseURL + "/TipoCabania/Name/");

                httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> getTiposCabania = httpClient.GetAsync(httpClient.BaseAddress + texto);
                
                getTiposCabania.Wait();

                if (getTiposCabania.Result.IsSuccessStatusCode)
                {
                    HttpContent contenido = getTiposCabania.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();

                    deseralize.Wait();

                    vmIndexTipoCabania.TiposCabania = JsonConvert.DeserializeObject<IEnumerable<VMTipoCabania>>(deseralize.Result);
                } else
                {
                    HttpContent contenido = getTiposCabania.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();
                    ViewBag.Mensaje = deseralize.Result;
                }

                vmIndexTipoCabania.Busqueda.SearchText = texto;

                if (!vmIndexTipoCabania.TiposCabania.Any())
                    TempData["Error"] = "No existen tipos de cabaña con ese nombre.";
            }
            
            return View(vmIndexTipoCabania);
        }

        [Logueado]
        public IActionResult Create()
        {
            return View();
        }

        [Logueado]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VMTipoCabania tipoCabania)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseURL + "/TipoCabania");

                httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> postTiposCabania = httpClient.PostAsJsonAsync(httpClient.BaseAddress, tipoCabania);
                
                postTiposCabania.Wait();

                if (postTiposCabania.Result.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Tipo de Cabaña ingresado con exito.";

                    VMIndexTipoCabania vmIndexTipoCabania = new();
                    return RedirectToAction("Index", vmIndexTipoCabania);
                }
                else
                {
                    HttpContent contenido = postTiposCabania.Result.Content;
                    Task<string> tarea2 = contenido.ReadAsStringAsync();
                    tarea2.Wait();

                    ViewBag.Error = tarea2.Result.ToString();
                    return View(tipoCabania);
                }
            } catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(tipoCabania);
            }
            
        }

        [Logueado]
        public IActionResult Edit(int id)
        {
            VMTipoCabania tipoCabania = new();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseURL + "/TipoCabania/" + id);

            httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            Task<HttpResponseMessage> getTipoCabania = httpClient.GetAsync(httpClient.BaseAddress);
            
            getTipoCabania.Wait();

            if (getTipoCabania.Result.IsSuccessStatusCode)
            {
                HttpContent contenido = getTipoCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                deseralize.Wait();

                tipoCabania = JsonConvert.DeserializeObject<VMTipoCabania>(deseralize.Result);
            } else
            {
                HttpContent contenido = getTipoCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();
                ViewBag.Mensaje = deseralize.Result;
            }
            return View(tipoCabania);
        }

        [Logueado]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VMTipoCabania tipoCabania)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseURL + "/TipoCabania/" + tipoCabania.Id);

                httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> putTipoCabania = httpClient.PutAsJsonAsync(httpClient.BaseAddress, tipoCabania);
                
                putTipoCabania.Wait();

                if (putTipoCabania.Result.IsSuccessStatusCode)
                {
                    TempData["Mensaje"] = "Tipo de cabaña modificado correctamente.";
                    return RedirectToAction("Index");
                } else
                {
                    HttpContent contenido = putTipoCabania.Result.Content;
                    Task<string> tarea2 = contenido.ReadAsStringAsync();
                    tarea2.Wait();

                    ViewBag.Error = tarea2.Result;
                    return View(tipoCabania);
                }
            } catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(tipoCabania);
            }
        }

        [Logueado]
        public IActionResult Delete(int id)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseURL + "/TipoCabania/" + id);

                httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> deleteTipoCabania = httpClient.DeleteAsync(httpClient.BaseAddress);
                
                deleteTipoCabania.Wait();

                if (deleteTipoCabania.Result.IsSuccessStatusCode)
                {
                    TempData["Mensaje"] = "Tipo de cabaña eliminado correctamente.";

                    VMIndexTipoCabania vmIndexTipoCabania = new();
                    return RedirectToAction("Index", vmIndexTipoCabania);
                } else
                {
                    HttpContent contenido = deleteTipoCabania.Result.Content;
                    Task<string> tarea2 = contenido.ReadAsStringAsync();

                    TempData["Error"] = tarea2.Result;

                    VMIndexTipoCabania vmIndexTipoCabania = new();

                    return RedirectToAction("Index", vmIndexTipoCabania);
                }             
            } catch (Exception e)
            {
                TempData["Error"] = e.Message;

                VMIndexTipoCabania vmIndexTipoCabania = new();

                return RedirectToAction("Index", vmIndexTipoCabania);
            }
        }
    }
}
