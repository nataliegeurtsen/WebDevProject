using Microsoft.AspNetCore.Mvc;

namespace WebDevProject.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}