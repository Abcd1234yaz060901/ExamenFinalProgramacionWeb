using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinalPWEB.Models
{
    public class TiposMembresia
    {
        [Key]
        public int MembresiaID { get; set; }

        [Display(Name = "Tipo de membresia")]
        public string Nombre { get; set; }
        [Display(Name = "Costo Mensual")]
        public int Costo { get; set; }
        public ICollection<Socio> Socio { get; set; }
    }
}