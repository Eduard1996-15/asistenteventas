using asistenteventas.Data;
using asistenteventas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asistenteventas.Controllers
{
    public class VendedorsController : Controller
    {
       private readonly ASISTENTE_DE_VENTASContext _context;

        public VendedorsController(ASISTENTE_DE_VENTASContext context)
        {
            _context = context;
        }

        public IActionResult Cargar()
        {
            return View(); 
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string n, string c)
        {
            // var usu = _context.Vendedors.FirstOrDefault(
              //  u => u.Nombre == n && u.Codigo == c);
              
            if (n=="usu1" && c=="12345")
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.mje = "login incorrecto";
                return View();
            }
                


            
        }
        // GET: Vendedors
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vendedors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vendedors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendedors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Vendedors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vendedors/Edit/5
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

        // GET: Vendedors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vendedors/Delete/5
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
