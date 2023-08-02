using Microsoft.AspNetCore.Mvc;//要using 這個才能用Session and Cookie
//using Newtonsoft.Json;
using System.Text.Json;
using prjMauiDemo.NewFolder2;
using prjMvcCoreDemo.Models;

namespace prjMvcCoreDemo.Controllers
{
    public class aController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string demoJson2Obj()
        {
            string json = demoObj2Json();
            TCustomer x = JsonSerializer.Deserialize<TCustomer>(json);
            return x.FName + "<br/>" + x.FPhone;
        }
        public string demoObj2Json()
        {
            TCustomer x = new TCustomer()
            {
                Fid = 1,
                FName = "marco",
                FPhone = "0987654321",
                FEmail = "marco@gmail.com",
                FAddress = "Taipei",
                FPassword = "1234"
            };
            string json = JsonSerializer.Serialize(x);
            return json;
        }
        public IActionResult showBySessionCount() //使用Session 完成存取資料的累加
        {
            int count = 0;

            if (HttpContext.Session.Keys.Contains("COUNT"))
                count = (int)HttpContext.Session.GetInt32("COUNT");
            count++;
                HttpContext.Session.SetInt32("COUNT", count);
            ViewBag.COUNT = count;
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
