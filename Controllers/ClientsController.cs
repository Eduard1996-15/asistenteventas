using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asistenteventas.Data;
using asistenteventas.Models;

namespace asistenteventas.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ASISTENTE_DE_VENTASContext _context;

        public ClientsController(ASISTENTE_DE_VENTASContext context)
        {
            _context = context;
        }

        // GET: Clients
     

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.CodCli == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

       
        public IActionResult CreateCliente()
        {
            if (HttpContext.Session.GetString("Vend") != null || HttpContext.Session.GetString("Admi") != null)
            {
                return View();
            }
            else { return RedirectToAction("Login", "Usuarios"); }

        }

        // POST: Clients/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCliente([Bind("CodCli,MailCli,PriNomCli,NroDocCli,PriApeCli,SegApeCli")] Client client)
        {

            if (ModelState.IsValid)
            {
                if (client == null)
                {
                    ViewBag.mje = "no se a creado cliente con exito";
                    return View();
                }

                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

      
    }
}
