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
        private ApplicationDbContext _context;

        public UnidadeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Unidade
        public ActionResult Index()
        {
            var unidade = _context.Unidades.ToList();

            if (User.IsInRole("CanManageAdm"))
                return View(unidade);

            return View("ReadOnlyIndex", unidade);
        }

        public ActionResult Detalhes(int id)
        {
            foreach (var unidade in _context.Unidades.ToList())
            {
                if (unidade.Id == id)
                {
                    return View(unidade);
                }
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "CanManageAdm")]
        public ActionResult New()
        {

            var viewModel = new UnidadeFormViewModel()
            {
                Unidade = new Unidade()
            };

            return View("UnidadeForm", viewModel);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Save(Unidade unidade) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new UnidadeFormViewModel
                {
                    Unidade = unidade,
                };

                return View("UnidadeForm", viewModel);
            }

            if (unidade.Id == 0)
                _context.Unidades.Add(unidade);
            else
            {
                var pacienteInDb = _context.Unidades.Single(c => c.Id == unidade.Id);

                pacienteInDb.Nome = unidade.Nome;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Unidade");
        }

        [Authorize(Roles = "CanManageAdm")]
        public ActionResult Edit(int id)
        {
            var unidade= _context.Unidades.SingleOrDefault(c => c.Id == id);

            if (unidade == null)
                return HttpNotFound();

            var viewModel = new UnidadeFormViewModel
            {
                Unidade = unidade
            };

            return View("UnidadeForm", viewModel);
        }

        [Authorize(Roles = "CanManageAdm")]
        public ActionResult Delete(int id)
        {
            var unidade = _context.Unidades.SingleOrDefault(c => c.Id == id);

            if (unidade == null)
                return HttpNotFound();

            _context.Unidades.Remove(unidade);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}