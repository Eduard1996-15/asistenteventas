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
        //cargar datos a la BD
        public IActionResult Cargar()
        {
            return View(); 
        }

        //busqueda
        public IActionResult Busqueda()
        {
            if (HttpContext.Session.GetString("Vend") != null)
            {  
                return View();

            }return RedirectToAction("Index");

          
        }
       
        public ActionResult Index()
        {
            var clientes = _context.Clients;
            return View( clientes);
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



        // GET: Clients/Create
        public IActionResult CreateCliente()
        {
            if(HttpContext.Session.GetString("Vend") != null || HttpContext.Session.GetString("Admi") != null) {
            return View();
            }else { return RedirectToAction("Login","Usuarios"); }
            
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCliente([Bind("CodCli,MailCli,PriNomCli,NroDocCli,PriApeCli,SegApeCli")] Client client)
        {
            
            if (ModelState.IsValid)
            {
                if(client==null) {
                ViewBag.mje = "no se a creado cliente con exito";
                    return View();
                } 
                
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(client);
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


        public ActionResult BuscarporTexto()
        {
           // if (HttpContext.Session.GetString("Usuario") != null)
            //{
                return View();
           // }
           /// else
           // {
            //    return RedirectToAction("Login", "Vendedors");
           // }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarporTexto(string descripcion)
        {
            try
            {
               IEnumerable<Modelo> modelos = _context.Modelos.Where(x => x.DesMod.Contains(descripcion));
                if (modelos != null && modelos.Count() > 0)
                {
                   // ViewBag.mod= modelos;
                    ViewBag.mje = " encontrado : ";
                    return View(modelos);
                }
                    ViewBag.mje = " No se encontro con esa descripcion ";
                     return View(); 
                
            }
            catch (Exception ex)
            {
                ViewBag.mje = "No se encontro con ese texto " + ex.Message;
                return View();
            }
        }
    }
}
