using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultorioMedico.Models;
using ConsultorioMedico.ViewModels;

namespace ConsultorioMedico.Controllers
{
    public class UnidadeController : Controller
    {
        public List<Unidade> Unidades = new List<Unidade>
        {
            new Unidade {Id = 1, Nome = "Unidade de Medida"},
            new Unidade {Id = 2, Nome = "U.B.S Amizade"}
        };

        // GET: Unidade
        public ActionResult Index()
        {
            var viewModel = new UnidadeIndexViewModel
            {
                Unidades = Unidades
            };
            return View(viewModel);
        }

        public ActionResult Detalhes(int id)
        {
            if (Unidades.Count < id)
            {
                return HttpNotFound();
            }

            var unidade = Unidades[id - 1];

            return View(unidade);
        }
    }
}