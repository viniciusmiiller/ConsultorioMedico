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

        public ActionResult New()
        {

            var viewModel = new ProfissionalFormViewModel()
            {
                Profissional = new Profissional()
            };

            return View("ProfissionalForm", viewModel);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Save(Profissional profissional) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProfissionalFormViewModel
                {
                    Profissional = profissional,
                };

                return View("ProfissionalForm", viewModel);
            }

            if (profissional.Id == 0)
                _context.Profissionais.Add(profissional);
            else
            {
                var pacienteInDb = _context.Profissionais.Single(c => c.Id == profissional.Id);

                pacienteInDb.Nome = profissional.Nome;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Profissional");
        }

        public ActionResult Edit(int id)
        {
            var profissional = _context.Profissionais.SingleOrDefault(c => c.Id == id);

            if (profissional == null)
                return HttpNotFound();

            var viewModel = new ProfissionalFormViewModel
            {
                Profissional = profissional
            };

            return View("ProfissionalForm", viewModel);
        }
    }
}