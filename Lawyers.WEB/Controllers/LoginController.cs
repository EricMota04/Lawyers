using Data.DAL.Context;
using Lawyers.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lawyers.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly LawyersContext _context;
        public LoginController(LawyersContext lawyersContext) { 
            _context = lawyersContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login(Lawyers.WEB.Models.Usuarios usuarioBuscar)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.USUARIOS!
                    .FirstOrDefaultAsync(x => x.Usuario == usuarioBuscar.Usuario && x.Contrasena == usuarioBuscar.Contrasena);

                if (user == null)
                {
                    TempData["Error"] = "Invalid username or password";
                    return View(usuarioBuscar);
                }

                string userJson = JsonConvert.SerializeObject(user);

                var session = HttpContext.Session;
                session.SetString("Usuario", userJson);
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserName", user.Usuario);
                return RedirectToAction("Index", "Casos");
                
            }

            return View(usuarioBuscar);
        }
    }
}
