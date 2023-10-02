using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }


        [Display(Name = "Número de Empleado")]
        public string NumeroEmpleado { get; set; }


        [MinLength(6), MaxLength(13)]
        public string RFC { get; set; }


        [Required]
        [Display(Name = "Nombre(s)")]
        public string Nombre { get; set; }


        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }


        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }


        [Required]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }


        [Compare("Email")]
        [Display(Name = "Confirmar Correo")]
        public string ConfirmEmail { get; set; }


        [Required]
        [MaxLength(10), MinLength(10)]
        public string Telefono { get; set; }


        [Display(Name = "Fecha de Nacimiento")]
        public string FechaNacimiento { get; set; }


        [MaxLength(11), MinLength(11)]
        public string NSS { get; set; }


        [Display(Name = "Fecha de Ingreso")]
        public string FechaIngreso { get; set; }


        public byte[] Foto { get; set; }


        [Required]
        public ML.Empresa Empresa { get; set; }


        public List<object> Empleados { get; set; }
    }
}
