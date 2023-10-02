using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }


        [Required]
        public string Calle { get; set; }


        [Required]
        [Display(Name = "Número Interior")]
        public string NumeroInterior { get; set; }


        [Required]
        [Display(Name = "Número Exterior")]
        public string NumeroExterior { get; set; }


        [Required]
        public ML.Colonia Colonia { get; set; }


        public List<object> Direcciones { get; set; }
    }
}
