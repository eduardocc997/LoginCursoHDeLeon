using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //Esto permite usar los corchectes de validacion

namespace CursoMVC.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress] //Verificar que sea correo
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)] //Requerimos que se tenga como minimo un caracter y maximo 100 para validar
        [Display(Name ="Correo Electrónico")] //Lo que queremos que se muestre en el label
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] //Para que el input sea tipo password
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)] //Para que el input sea tipo password
        [Compare("Password", ErrorMessage ="Las contraseñas no coinciden")] //Le decimos que compare si la variable Password y la que sigue (ConfirmPassword) son iguales, es como un if
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }
}