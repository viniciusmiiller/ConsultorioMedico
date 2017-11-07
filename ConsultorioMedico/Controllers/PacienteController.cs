using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultorioMedico.Models;
using ConsultorioMedico.ViewModels;

namespace ConsultorioMedico.Controllers
{
    public class PacienteController : Controller
    {
        private ApplicationDbContext _context;

        public PacienteController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Paciente
        public ActionResult Index()
        {
            var paciente = _context.Pacientes.ToList();
            return View(paciente);
        }

        public ActionResult Detalhes(int id)
        {
            var paciente = _context.Pacientes.SingleOrDefault(c => c.Id == id);
            if (paciente == null)
                return HttpNotFound();

            return View(paciente);
        }

        public ActionResult New()
        {

            var viewModel = new PacienteFormViewModel()
            {
                Paciente = new Paciente()
            };

            return View("PacienteForm", viewModel);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Save(Paciente paciente) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PacienteFormViewModel
                {
                    Paciente = paciente,
                };

                return View("PacienteForm", viewModel);
            }

            if (paciente.Id == 0)
                _context.Pacientes.Add(paciente);
            else
            {
                var pacienteInDb = _context.Pacientes.Single(c => c.Id == paciente.Id);

                pacienteInDb.Nome = paciente.Nome;
                pacienteInDb.IsSub = paciente.IsSub;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Paciente");
        }

        public ActionResult Edit(int id)
        {
            var paciente = _context.Pacientes.SingleOrDefault(c => c.Id == id);

            if (paciente == null)
                return HttpNotFound();

            var viewModel = new PacienteFormViewModel
            {
                Paciente = paciente
            };

            return View("PacienteForm", viewModel);
        }
    }
}