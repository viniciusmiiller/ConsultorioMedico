using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultorioMedico.Models;
using ConsultorioMedico.ViewModels;
using System.Data.Entity;

namespace ConsultorioMedico.Controllers
{
    public class AgendaController : Controller
    {
        private ApplicationDbContext _context;

        public AgendaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public List<Agenda> Agendas = new List<Agenda>
        {
        };

        // GET: Agenda
        public ActionResult Index()
        {
            var agenda = _context.Agendas.Include(a => a.Profissional);

            if (User.IsInRole("CanManageCustomers"))
                return View(agenda);

            return View("ReadOnlyIndex", agenda);
        }

        public ActionResult Detalhes(int id)
        {
            var agenda = _context.Agendas.Include(c => c.Profissional).SingleOrDefault(c => c.Id == id);

            if (agenda == null)
                return HttpNotFound();

            return View(agenda);
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult New()
        {
            var profissionais = _context.Profissionais.ToList();

            var viewModel = new AgendaFormViewModel()
            {
                Agenda = new Agenda(),
                Profissional = profissionais
            };

            return View("AgendaForm", viewModel);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Save(Agenda agenda) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AgendaFormViewModel
                {
                    Agenda = agenda,
                    Profissional = _context.Profissionais.ToList()
            };

                return View("AgendaForm", viewModel);
            }

            if (agenda.Id == 0)
                _context.Agendas.Add(agenda);
            else
            {
                var agendaInDb = _context.Agendas.Single(c => c.Id == agenda.Id);

                agendaInDb.DiaSemana = agenda.DiaSemana;
                agendaInDb.Vagas = agenda.Vagas;
                agendaInDb.ProfissionalId = agenda.ProfissionalId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Agenda");
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Edit(int id)
        {
            var agenda = _context.Agendas.SingleOrDefault(c => c.Id == id);

            if (agenda == null)
                return HttpNotFound();

            var viewModel = new AgendaFormViewModel
            {
                Agenda = agenda,
                Profissional = _context.Profissionais.ToList()
            };

            return View("AgendaForm", viewModel);
        }

        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Delete(int id)
        {
            var agenda = _context.Agendas.SingleOrDefault(c => c.Id == id);

            if (agenda == null)
                return HttpNotFound();

            _context.Agendas.Remove(agenda);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}