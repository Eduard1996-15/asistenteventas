using asistenteventas.Data;
using asistenteventas.Models;
using Asistenteventas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using Tensorflow.Framework;

namespace asistenteventas.Controllers
{
    public class VendedorsController : Controller
    {
       private readonly ASISTENTE_DE_VENTASContext _context;
        private readonly DbSet<Stock> _stockDbSet;
        public VendedorsController(ASISTENTE_DE_VENTASContext context)
        {
            _context = context;
            _stockDbSet = _context.Set<Stock>();
        }
        private IEnumerable<Stock> _stocks;
        //busqueda
        public ActionResult Busqueda()
        {
            if (HttpContext.Session.GetString("Vend") != null)
            {  
                return View();

            }return RedirectToAction("Login", "Usuarios");

          
        }
        [HttpPost]
        public ActionResult Busqueda(string imagen)
        {
            _stocks = null;
            try {

                if (imagen != null && imagen.Length > 0) {
                    byte[] bytes = Convert.FromBase64String(imagen);

                    //Load sample data
                    ClasificarImg.ModelInput sampleData = new ClasificarImg.ModelInput()
                    {
                        ImageSource = bytes,
                    };

                    ClasificarImgColor.ModelInput sampleDatacolor = new ClasificarImgColor.ModelInput()
                    {
                        ImageSource = bytes,
                    };

                    //Load model and predict output
                    string color = ClasificarImgColor.Predict(sampleDatacolor).PredictedLabel;


                    //Load model and predict output
                    var tipo = ClasificarImg.Predict(sampleData).PredictedLabel;

                   IEnumerable<Stock> stocks = null;

				        stocks = _stockDbSet.Where(x => x.DesDetArt==tipo).ToList();
                    if (stocks != null && stocks.Count() > 0)
					{
                        _stocks = stocks;
						  return RedirectToAction("Stock");
					}
                    else
                    {
                        ViewBag.mje = "No se encontraron modelos con esa foto.";
                        return View();

                    }


                }
                return View();


            }
			catch (Exception ex)
            {
				ViewBag.mje = "Error al buscar por foto: " + ex.Message;
				return View();
			}
		}

     
        public ActionResult Stock()
        {
            if (HttpContext.Session.GetString("Vend") != null)
            {
				ViewBag.mje = "Modelos encontrados:";
				return View(_stocks);

            }
            return RedirectToAction("Usuarios","Login");
        }


        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string txtbuscar)
        {

            try
            {
                var cliente = _context.Clients.FirstOrDefault(x => x.NroDocCli.Contains(txtbuscar));
                if (cliente != null)
                {
                    // ViewBag.mod= modelos;
                    ViewBag.mje = " encontrado : ";
                    ViewBag.cli = cliente;
                    return View(cliente);
                }
                ViewBag.mje = " No se encontro con esa cedula ";
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.mje = "No se encontro con ese texto " + ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id.ToString() == null || _context.Vendedors == null)
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

        // GET: Administradors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id.ToString() == null || _context.Vendedors == null)
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

        // GET: Administradors/Delete/5
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

        // POST: Administradors/Delete/5
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


        public ActionResult BuscarporTexto()
        {
            if (HttpContext.Session.GetString("Vend") != null)
            {
            return View();
            }
             else
            {
               return RedirectToAction("Login", "Usuarios");
             }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarporTexto(string descripcion)
        {
            try
            {
                IEnumerable<Stock> modelos = _stockDbSet.Where(x => x.DesArt.Contains(descripcion) || x.DesDetArt.Contains(descripcion));
                if (modelos != null && modelos.Count() > 0)
                {
                    ViewBag.mje = "Modelos encontrados:";
                    return View(modelos);
                }

                ViewBag.mje = "No se encontraron modelos con esa descripción.";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.mje = "Error al buscar por texto: " + ex.Message;
                return View();
            }
        }

    }
}
