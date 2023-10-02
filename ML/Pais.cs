﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Pais
    {
        [Display(Name = "Pais")]
        public int IdPais { get; set; }
        public string Nombre { get; set; }
        public List<object> Paises { get; set; }
    }
}
