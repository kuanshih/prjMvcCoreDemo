using Microsoft.AspNetCore.Mvc;
using prjMauiDemo.NewFolder2;

namespace prjMvcCoreDemo.Controllers
{
    public class aController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string sayHello()
        {
            return "Hello my first asp.Net Mvc Core project";
        }
        public string lotto()
        {
            return (new CLotto()).getNumber();
        }
        public IActionResult showById()
        {
            return View();
        }
    }
}
