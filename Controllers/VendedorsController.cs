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
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string n, string c)
        {
            var usu = _context.Vendedors.FirstOrDefault(
                u => u.Nombre == n && u.Codigo == c);
              
            if (usu!=null)
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
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCliente([Bind("CodCli,DirCli,NroDocCli,TelCli,MailCli,FecNacCli,ObsCli,FecAltCli,LugAltCli,FecActCli,HorActCli,LugActCli,FlgCliLoc,CodDpt,CodZon,PriNomCli,SegNomCli,PriApeCli,SegApeCli,NroNomCli,SexCli,CelCli,UltCmpCli,CodPais,TipDocCli,CiuCli,AltWebCli,CarTelCli")] Client client)
        {
            if (ModelState.IsValid)
            {
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
    }
}
