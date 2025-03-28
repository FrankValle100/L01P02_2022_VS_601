using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Vistas_y_Variables_de_Sesión.Servicios
{
    public class AutenticacionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Verificar si la variable de sesión "UsuarioId" existe
            var usuarioId = context.HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                // Si no está autenticado, redirigir a la página de login
                context.Result = new RedirectToActionResult("Autenticar", "Home", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
