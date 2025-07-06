using Microsoft.AspNetCore.Mvc;
using GestionInventario.Models;

namespace GestionInventario.Controllers
{
    public class ProductoController : Controller
    {
        private static List<Producto> productos = new List<Producto>();
        private int nextId = 1;
        public IActionResult Index()
        {
            return View(productos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (!ModelState.IsValid) return View(producto);
            producto.Id = nextId++;
            productos.Add(producto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producto producto)
        {
            if (!ModelState.IsValid) return View(producto);
            var existingProducto = productos.FirstOrDefault(p => p.Id == producto.Id);
            if (existingProducto == null) return NotFound();
            existingProducto.Nombre = producto.Nombre;
            existingProducto.Descripcion = producto.Descripcion;
            existingProducto.Precio = producto.Precio;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            productos.Remove(producto);
            return RedirectToAction("Index");
        }
    }
}
