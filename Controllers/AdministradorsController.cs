using asistenteventas.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asistenteventas.Controllers
{
    public class AdministradorsController : Controller
    {



        private readonly ASISTENTE_DE_VENTASContext _context;

        public AdministradorsController(ASISTENTE_DE_VENTASContext context)
        {
            _context = context;
        }

        // GET: AdministradorsController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdministradorsController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       

    }
}
