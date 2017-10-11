using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultorioMedico.Models;
using ConsultorioMedico.ViewModels;

namespace ConsultorioMedico.Controllers
{
    public class ProfissionalController : Controller
    {
        private ApplicationDbContext _context;

        public ProfissionalController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Profissional
        public ActionResult Index()
        {
            var profissional = _context.Profissionais.ToList();
            return View(profissional);
        }

        public ActionResult Detalhes(int id)
        {
            foreach (var profissional in _context.Profissionais.ToList())
            {
                if (profissional.Id == id)
                {
                    return View(profissional);
                }
            }
            return HttpNotFound();
        }
    }
}