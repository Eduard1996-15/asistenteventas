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
    public class Administradors1Controller : Controller
    {
        private readonly ASISTENTE_DE_VENTASContext _context;

        public Administradors1Controller(ASISTENTE_DE_VENTASContext context)
        {
            _context = context;
        }

        // GET: Administradors1
        public async Task<IActionResult> Index()
        {
            var aSISTENTE_DE_VENTASContext = _context.Administradors.Include(a => a.CodigoNavigation);
            return View(await aSISTENTE_DE_VENTASContext.ToListAsync());
        }

        // GET: Administradors1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Administradors == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradors
                .Include(a => a.CodigoNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // GET: Administradors1/Create
        public IActionResult Create()
        {
            ViewData["Codigo"] = new SelectList(_context.Usuarios, "Codigo", "Codigo");
            return View();
        }

        // POST: Administradors1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nombre")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codigo"] = new SelectList(_context.Usuarios, "Codigo", "Codigo", administrador.Codigo);
            return View(administrador);
        }

        // GET: Administradors1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Administradors == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradors.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }
            ViewData["Codigo"] = new SelectList(_context.Usuarios, "Codigo", "Codigo", administrador.Codigo);
            return View(administrador);
        }

        // POST: Administradors1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Codigo,Nombre")] Administrador administrador)
        {
            if (id != administrador.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codigo"] = new SelectList(_context.Usuarios, "Codigo", "Codigo", administrador.Codigo);
            return View(administrador);
        }

        // GET: Administradors1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Administradors == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradors
                .Include(a => a.CodigoNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // POST: Administradors1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Administradors == null)
            {
                return Problem("Entity set 'ASISTENTE_DE_VENTASContext.Administradors'  is null.");
            }
            var administrador = await _context.Administradors.FindAsync(id);
            if (administrador != null)
            {
                _context.Administradors.Remove(administrador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradorExists(string id)
        {
          return (_context.Administradors?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
