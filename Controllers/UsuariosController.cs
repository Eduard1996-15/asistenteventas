using asistenteventas.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asistenteventas.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ASISTENTE_DE_VENTASContext _context;
        public UsuariosController(ASISTENTE_DE_VENTASContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        { 
            return View();
        }
        [HttpPost]
            public IActionResult Login(string n, string c)
            {
            try
            {
                var usu = _context.Vendedors.FirstOrDefault(
                u => u.Nombre == n && u.Contrasenia == c);

                if (usu != null)
                {
                    HttpContext.Session.SetString("Vend", usu.Nombre);//guardo el id
                    return RedirectToAction("Index", "Vendedors");
                }
                else
                {
                    var admi = _context.Administradors.FirstOrDefault(
                    u => u.Nombre == n && u.Contrasenia == c);
                    if (admi != null)
                    {
                        HttpContext.Session.SetString("Admi", admi.Nombre);//guardo el id
                        return RedirectToAction("Index", "Administradors");
                    }
                    else
                    {
                        ViewBag.mje = "login incorrecto";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.mje = "login incorrecto" + ex.Message;
                return View();
            }
        }
        // GET: Vendedors
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("Vend") != null || 
                HttpContext.Session.GetString("Admi") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        [HttpPost]
        public IActionResult Logout(string n)
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Vend");
            HttpContext.Session.Remove("Admi");
            return RedirectToAction("Login");
        }

    }
}
