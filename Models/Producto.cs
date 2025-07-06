using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models
{
    public class Producto
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(20, ErrorMessage = "El nombre del producto no puede exceder los 20 caracteres.")]
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cantidad del producto es obligatoria.")]
        [StringLength(100, ErrorMessage = "La descripción del producto no puede exceder los 100 caracteres.")]
        [Display(Name = "Descripción del Producto")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        [Display(Name = "Precio del Producto")]
        public decimal Precio { get; set; }
    }
}
