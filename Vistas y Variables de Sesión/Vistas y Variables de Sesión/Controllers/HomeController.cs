using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Vistas_y_Variables_de_Sesión.Models;

namespace Vistas_y_Variables_de_Sesión.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Autenticacion]
        public IActionResult Index()
        {
            //ViewData["Mensaje"] = "Hola desde ViewData";
            //ViewData["Numero"] = 123;

            //Recuperemos las variables de UsuarioId y TipoUsuario
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            var tipoUsuario = HttpContext.Session.GetString("tipoUsuario");
            var nombreUsuario = HttpContext.Session.GetString("Nombre");

            if (usuarioId == null)
            {
                // Si no existe la seccion, redirigir al login 
                return RedirectToAction("Autenticar" , "Home");

            }

            //Retorno informatica a la vista por ViewDatg y Viewdata
            ViewBag.nombre = nombreUsuario;
            ViewData["tipoUsuario"] = tipoUsuario;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Autenticar(string txtUsuario, string txtClave)
        {
            ////  // Valido al usuario con la base de datos
            var usuario = (from u in _context.usuarios
                           where u.email == txtUsuario
                           && u.contrasenia == txtClave
                           && u.activo == "S"
                           && u.blogueado == "N"
                           select u).FirstOrDefault();

            ////  // Si el usuario existe con todas sus validaciones
            if (usuario != null)
            {
                // Se crean las variables de sesión
                HttpContext.Session.SetInt32("UsuarioId", usuario.id_usuario);
                HttpContext.Session.SetString("TipoUsuario", usuario.tipo_usuario);
                HttpContext.Session.SetString("Nombre", usuario.nombre);

                // Se redirecciona al método de Index del controlador Home
                return RedirectToAction("Index", "Home");
            }

            //// // Muestra por ViewData un error
            ViewData["ErrorMessage"] = "Error, usuario inválido!!";

            return View();
        }

        public IActionResult Autenticar()
        {
            ViewData["ErrorMenssage"] = "";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
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
