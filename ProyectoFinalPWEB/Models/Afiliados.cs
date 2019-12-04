using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinalPWEB.Models
{
    public class Afiliados
    {
        [Key]
        public int AfiliadosID { get; set; }

        [Display(Name = "Nombre del Afiliado")]
        public string Nombre { get; set; }
        [Display(Name = "Parentesco")]
        public string Parentesco { get; set; }
        public ICollection<Socio> Socio { get; set; }
    }
}