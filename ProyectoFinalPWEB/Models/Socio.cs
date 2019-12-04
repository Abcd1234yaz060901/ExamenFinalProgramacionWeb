using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinalPWEB.Models
{
    public class Socio
    {
        [Key]

        public int SocioId { get; set; }
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public byte[] Foto { get; set; }

        [DataType(DataType.MultilineText)]
        public string Direccion { get; set; }
        [Display(Name = "Telefono/Celular/FAX")]
        public string Telefonos { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Afiliados")]
        public int AfiliadosID { get; set; }
        public Afiliados Afiliados { get; set; }
        [Display(Name = "Tipo de membresia")]
        public int MembresiaID { get; set; }
        public TiposMembresia TiposMembresia { get; set; }

        [Display(Name = "Lugar de trabajo")]
        public DateTime LugarDeTrabajo { get; set; }
        [Display(Name = "Direccion de la oficina")]
        public string DireccionOficina { get; set; }
        [Display(Name = "Telefono de la oficina")]
        public string TelefonoOficina { get; set; }
        [Display(Name = "Activo")]
        public bool Estado { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de ingreso")]
        public DateTime FechaIngreso { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de salida")]
        public DateTime FechaSalida { get; set; }

    }
}