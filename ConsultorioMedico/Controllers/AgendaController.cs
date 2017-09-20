using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultorioMedico.Models;
using ConsultorioMedico.ViewModels;

namespace ConsultorioMedico.Controllers
{
    public class AgendaController : Controller
    {
        public List<Agenda> Agendas = new List<Agenda>
        {
            new Agenda {DiaSemana = "Segunda", Id = 1, Vagas = 5, Profissional = "Vinícius Miiller"},
            new Agenda {DiaSemana = "Sexta", Id = 2, Vagas = 4, Profissional = "Maria Luiza"}
        };

        // GET: Agenda
        public ActionResult Index()
        {
            var viewModel = new AgendaIndexViewModel
            {
                Agendas = Agendas
            };
            return View(viewModel);
        }

        public ActionResult Detalhes(int id)
        {
            if (Agendas.Count < id)
            {
                return HttpNotFound();
            }

            var agenda = Agendas[id - 1];

            return View(agenda);
        }
    }
}