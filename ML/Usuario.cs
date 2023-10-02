using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }


        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }


        [Required]
        [Display(Name = "Nombre(s)")]
        public string Nombre { get; set; }


        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }


        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }


        [Required]
        //Primeros parametros reciben cualquier caracter, despues el @ y al final el . y 2 o 4 caracteres
        //[RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Correo Invalido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }


        [Required]
        [Compare("Email")]
        [Display(Name = "Confirmar Correo")]
        public string ConfirmEmail { get; set; }


        [Required]
        //Longitud de 6 a 15, una letra Mayuscula, una en Minuscula, un digito y un caracter especial
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,20}$", ErrorMessage = "La contraseña debe tener entre 6 y 20 caracteres y contener una letra mayúscula, una letra minúscula, un dígito y un carácter especial.")]
        [Display(Name = "Contraseña")]
        [MaxLength(20), MinLength(6)]
        public string Password { get; set; }


        [Required]
        [Compare("Password")]
        [MaxLength(20), MinLength(6)]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }


        [Required]
        public string Sexo { get; set; }


        [Required]
        [MaxLength(10), MinLength(10)]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Se debe colocar solo numeros")]
        [Display(Name = "Telefono Fijo")]
        public string Telefono { get; set; }


        [MaxLength(10), MinLength(10)]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Se debe colocar solo numeros")]
        [Display(Name = "Telefono Celular")]
        public string Celular { get; set; }


        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }


        [MaxLength(18), MinLength(18)]
        public string CURP { get; set; }


        public byte[] Imagen { get; set; }

        public bool Status { get; set; }


        [Required]
        public ML.Rol Rol { get; set; }


        [Required]
        public ML.Direccion Direccion { get; set; }


        public List<object> Usuarios { get; set; }
    }
}
