using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsultorioMedico.Models;

namespace ConsultorioMedico.ViewModels
{
    public class AgendaFormViewModel
    {
        public Agenda Agenda { get; set; }
        public IEnumerable<Profissional> Profissional { get; set; }
        public string Title
        {
            get
            {
                if (Agenda != null && Agenda.Id != 0)
                    return "Editar Agenda";

                return "Novo Agenda";
            }
        }
    }
}