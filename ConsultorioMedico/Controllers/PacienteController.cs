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
        public List<Paciente> Pacientes = new List<Paciente>
        {
            new Paciente {Nome = "Melina Caregnato", Id = 1},
            new Paciente {Nome = "Milena Joly", Id = 2}
        };

        // GET: Paciente
        public ActionResult Index()
        {
            var viewModel = new PacienteIndexViewModel
            {
                Pacientes = Pacientes
            };
            return View(viewModel);
        }

        public ActionResult Detalhes(int id)
        {
            if (Pacientes.Count < id)
            {
                return HttpNotFound();
            }

            var paciente = Pacientes[id - 1];

            return View(paciente);
        }
    }
}