using HotelCabañas.Models;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelCabañas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IRepositorioUsuario repositorioUsuarios;

        public HomeController(ILogger<HomeController> logger, IRepositorioUsuario repositorio)
        {
            _logger = logger;
            repositorioUsuarios = repositorio;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VMLogin vmLogin)
        {
            string email = vmLogin.Email;
            string contrasena = vmLogin.Contrasena;

            Usuario usuario = repositorioUsuarios.LoguearUsuario(email, contrasena);

            if (usuario != null)
            {
                HttpContext.Session.SetString("EMAIL", usuario.Mail);
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrecto.";
                return View();
            }

        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("EMAIL");
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