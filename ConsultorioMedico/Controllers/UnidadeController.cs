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
            return View(unidade);
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
    }
}