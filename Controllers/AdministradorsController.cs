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
    public class AdministradorsController : Controller
    {
        private readonly ASISTENTE_DE_VENTASContext _context;

        public AdministradorsController(ASISTENTE_DE_VENTASContext context)
        {
            _context = context;
        }

        // GET: Administradors1
        public async Task<IActionResult> Index()
        {
            var aSISTENTE_DE_VENTASContext = _context.Vendedors;
            return View(await aSISTENTE_DE_VENTASContext.ToListAsync());
        }

       

    }
}
