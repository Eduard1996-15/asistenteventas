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

        // GET: Administradors1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id.ToString() == null  || _context.Vendedors == null)
            {
                return NotFound();
            }

            var vendedores = await _context.Vendedors
                .FirstOrDefaultAsync(m => m.id == id);
            if (vendedores == null)
            {
                return NotFound();
            }

            return View(vendedores);
        }

        // GET: Administradors1/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Administradors1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Contrasenia,Nombre")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(vendedor);
        }

        // GET: Administradors1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id.ToString()==null || _context.Vendedors == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedors.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            
            return View(vendedor);
        }

        // POST: Administradors1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Contrasenia,Nombre")] Vendedor vendedor)
        {
            if (id != vendedor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedor);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorsExists(vendedor.id))
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
            return View();
        }

        // GET: Administradors1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id.ToString() == null || _context.Vendedors == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedors
               
                .FirstOrDefaultAsync(m => m.id == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // POST: Administradors1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendedors == null)
            {
                return Problem("Entity set 'ASISTENTE_DE_VENTASContext.Vendedors'  is null.");
            }
            var vendedor = await _context.Vendedors.FindAsync(id);
            if (vendedor != null)
            {
                _context.Vendedors.Remove(vendedor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorsExists(int id)
        {
          return (_context.Vendedors?.Any(e => e.id == id)).GetValueOrDefault();
        }

    }
}
