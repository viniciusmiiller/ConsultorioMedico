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
        public List<Profissional> Profissionais = new List<Profissional>
        {
            new Profissional {Nome = "Maria Luiza", Id = 1},
            new Profissional {Nome = "Vinícius Miiller", Id = 2}
        };

        // GET: Profissional
        public ActionResult Index()
        {
            var viewModel = new ProfissionalIndexViewModel
            {
                Profissionais = Profissionais
            };
            return View(viewModel);
        }

        public ActionResult Detalhes(int id)
        {
            if (Profissionais.Count < id)
            {
                return HttpNotFound();
            }

            var profissional = Profissionais[id - 1];

            return View(profissional);
        }
    }
}