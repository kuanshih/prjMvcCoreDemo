using Microsoft.AspNetCore.Mvc;

namespace prjMvcCoreDemo.Controllers
{
    public class Shopping : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
