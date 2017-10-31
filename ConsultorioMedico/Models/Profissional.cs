using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultorioMedico.Models
{
    public class Profissional
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}