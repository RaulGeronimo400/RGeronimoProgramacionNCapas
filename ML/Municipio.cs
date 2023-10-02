﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Municipio
    {
        [Display(Name ="Municipio")]
        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }

        [Required]
        public ML.Estado Estado { get; set; }
        public List<object> Municipios { get; set; }
    }
}
