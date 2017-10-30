using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsultorioMedico.Models;

namespace ConsultorioMedico.ViewModels
{
    public class ProfissionalFormViewModel
    {
        public Profissional Profissional { get; set; }
        public string Title
        {
            get
            {
                if (Profissional != null && Profissional.Id != 0)
                    return "Editar Profissional";

                return "Novo Profissional";
            }
        }
    }
}