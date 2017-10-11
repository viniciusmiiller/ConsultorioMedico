using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultorioMedico.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public String DiaSemana { get; set; }
        public int Vagas { get; set; }
        public Profissional Profissional { get; set; }
    }
}