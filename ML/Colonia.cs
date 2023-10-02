using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Colonia
    {
        [Display(Name ="Colonia")]
        public int IdColonia { get; set; }
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }


        [Required]
        public ML.Municipio Municipio { get; set; }
        public List<object> Colonias { get; set; }
    }
}
