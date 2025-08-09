using GestionInventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventario.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>();
        private static int nextId = 1;

        static UserController()
        {
            if (users.Count == 0)
            {
                users.Add(new User
                {
                    Id = nextId++,
                    Name = "Estrella",
                    Username = "King",
                    Password = "1234",
                    ConfirmPassword = "1234"
                });
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid) return View(login);

            var existingUser = users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (existingUser != null)
            {
                return RedirectToAction("Index", "Producto");
            }

            ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
            return View(login);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid) return View(user);
            if (users.Any(u => u.Username == user.Username))
            {
                ModelState.AddModelError("Username", "El nombre de usuario ya está en uso.");
                return View(user);
            }
            user.Id = nextId++;
            users.Add(user);
            Console.WriteLine($"Usuario registrado: {user.Username}");
            return RedirectToAction("Login");
        }
    }
}
