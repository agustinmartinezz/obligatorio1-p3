using HotelCabañas.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace HotelCabañas.Controllers
{
    public class HomeController : Controller
    {
        private const string baseURL = "http://localhost:5256/api";

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginError()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(VMLogin vmLogin)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseURL + "/Usuario/Login");
           
            Task<HttpResponseMessage> postLogin = httpClient.PostAsJsonAsync(httpClient.BaseAddress, vmLogin);
            postLogin.Wait();

            if (postLogin.Result.IsSuccessStatusCode) {
                HttpContent contenido = postLogin.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                deseralize.Wait();
                vmLogin = JsonConvert.DeserializeObject<VMLogin>(deseralize.Result);

                if (vmLogin.Token != null)
                {
                    HttpContext.Session.SetString("token", vmLogin.Token);
                }
                return View("~/Views/Home/Index.cshtml");
            } else
            {
                HttpContent contenido = postLogin.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                ViewBag.Error = deseralize.Result;

                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(VMLogin vmRegistro)
        {
            if (vmRegistro != null) {
                if (vmRegistro.Nombre == null || vmRegistro.Mail == null  || vmRegistro.Contrasenia == null) {
                    ViewBag.Error = "Debe ingresar todos los datos.";
                } else
                {
                    HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri(baseURL + "/Usuario");

                    Task<HttpResponseMessage> postRegister = httpClient.PostAsJsonAsync(httpClient.BaseAddress, vmRegistro);
                    postRegister.Wait();

                    if (postRegister.Result.IsSuccessStatusCode)
                    {
                        HttpContent contenido = postRegister.Result.Content;
                        Task<string> deseralize = contenido.ReadAsStringAsync();

                        deseralize.Wait();

                        vmRegistro = JsonConvert.DeserializeObject<VMLogin>(deseralize.Result);

                        if (vmRegistro.Token != null)
                        {
                            HttpContext.Session.SetString("token", vmRegistro.Token);
                        }

                        return View("~/Views/Home/Index.cshtml");

                    } else
                    {
                        HttpContent contenido = postRegister.Result.Content;
                        Task<string> deseralize = contenido.ReadAsStringAsync();

                        ViewBag.Error = deseralize.Result;
                    }
                }
            } else
            {
                ViewBag.Error = "Debe ingresar todos los datos.";
            }

            return View(vmRegistro);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            return View("~/Views/Home/Login.cshtml");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}