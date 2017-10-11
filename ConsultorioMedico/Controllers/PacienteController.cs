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
            foreach (var paciente in _context.Pacientes.ToList())
            {
                if (paciente.Id == id)
                {
                    return View(paciente);
                }
            }
            return HttpNotFound();
        }
    }
}