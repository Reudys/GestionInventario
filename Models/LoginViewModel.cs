using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(10, ErrorMessage = "El nombre de usuario no puede exceder los 10 caracteres.")]
        [MinLength(3, ErrorMessage = "El nombre de usuario debe tener 3 o más caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [StringLength(8, ErrorMessage = "La contraseña no debe pasar los 8.")]
        [MinLength(4, ErrorMessage = "La contraseña debe tener más de 4 caracteres.")]
        public string Password { get; set; }
    }
}
