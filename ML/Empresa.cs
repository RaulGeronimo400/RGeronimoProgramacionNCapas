using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Empresa
    {
        [Display(Name = "Empresa")]
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public List<object> Empresas { get; set; }
    }
}
