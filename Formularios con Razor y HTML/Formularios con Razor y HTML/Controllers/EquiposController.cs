using Formularios_con_Razor_y_HTML.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Formularios_con_Razor_y_HTML.Controllers
{
    public class EquiposController : Controller
    {
        public IActionResult Index()
        {
            // Obtener lista de marcas desde la base de datos
            var listaDeMarcas = (from m in _equiposDbContext.marcas
                                 select m).ToList();

            // Pasar la lista de marcas al ViewData para usarla en un dropdown (SelectList)
            ViewData["ListadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            // Obtener listado de equipos con información de marca (usando join)
            var listadoDeEquipos = (from e in _equiposDbContext.equipos
                                    join m in _equiposDbContext.marcas on e.marca_id equals m.id_marcas
                                    select new
                                    {
                                        nombre = e.nombre,
                                        description = e.description,
                                        marca_id = e.marca_id,
                                        marca_nombre = m.nombre_marca
                                    }).ToList();

            // Pasar el listado de equipos al ViewData
            ViewData["ListadoEquipo"] = listadoDeEquipos;

            return View();
        }

        public IActionResult CrearEquipos(equipos nuevaEquipo)
        {
            _equiposDbContext.Add(nuevaEquipo);
            _equiposDbContext.SaveChanges();
            return RedirectToAction();
        }
        


    }
}
