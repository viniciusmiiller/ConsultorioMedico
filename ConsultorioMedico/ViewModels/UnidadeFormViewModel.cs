using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsultorioMedico.Models;

namespace ConsultorioMedico.ViewModels
{
    public class UnidadeFormViewModel
    {
        public Unidade Unidade { get; set; }
        public string Title
        {
            get
            {
                if (Unidade != null && Unidade.Id != 0)
                    return "Editar Unidade";

                return "Novo Unidade";
            }
        }
    }
}