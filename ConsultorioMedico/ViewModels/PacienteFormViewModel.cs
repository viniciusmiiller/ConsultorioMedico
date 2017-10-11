using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsultorioMedico.Models;

namespace ConsultorioMedico.ViewModels
{
    public class PacienteFormViewModel
    {
        public Paciente Paciente { get; set; }
        public string Title
        {
            get
            {
                if (Paciente != null && Paciente.Id != 0)
                    return "Editar Paciente";

                return "Novo Paciente";
            }
        }
    }
}