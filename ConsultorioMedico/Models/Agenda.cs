using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultorioMedico.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        [Required]
        public String DiaSemana { get; set; }
        [Required]
        public int Vagas { get; set; }
        public Profissional Profissional { get; set; }
        [Required]
        public int ProfissionalId { get; set; }
    }
}