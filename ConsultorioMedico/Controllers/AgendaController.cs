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
            return View(agenda);
        }

        public ActionResult Detalhes(int id)
        {
            foreach (var agenda in _context.Agendas.ToList())
            {
                if (agenda.Id == id)
                {
                    return View(agenda);
                }
            }
            return HttpNotFound();
        }
    }
}