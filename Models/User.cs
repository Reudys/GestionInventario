using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models
{
    public class User
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(15, ErrorMessage = "El nombre no puede exceder los 15 caracteres.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(10, ErrorMessage = "El nombre de usuario no puede exceder los 10 caracteres.")]
        [Display(Name = "Nombre de Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(8,ErrorMessage = "La contraseña debe tener más de 4 caracteres y tener menos de 8.")]
        [MinLength(4, ErrorMessage = "La contraseña debe tener más de 4 caracteres.")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe confirmar la contraseña.")]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }
    }
}
