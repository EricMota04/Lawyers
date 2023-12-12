using Microsoft.AspNetCore.Mvc;

namespace Lawyers.WEB.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Logout()
        {
            var session = HttpContext.Session;
            session.Clear();
           
            return RedirectToAction("Login", "Login");
        }
    }
}
