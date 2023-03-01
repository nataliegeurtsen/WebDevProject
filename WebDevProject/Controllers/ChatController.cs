using Microsoft.AspNetCore.Mvc;
using WebDevProject.Models;

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
