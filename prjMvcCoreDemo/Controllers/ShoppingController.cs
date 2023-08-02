using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Newtonsoft.Json;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;
using System.Text.Json;

namespace prjMvcCoreDemo.Controllers
{
    public class ShoppingController : SuperController
    {
        public IActionResult CartView()
        {
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_PURCHASED_PRODUCTS_LIST))
                return RedirectToAction("List");

            string  json = HttpContext.Session.GetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            return View(cart);
        }
        public IActionResult List()
        {
            DbDemoContext ctx = new DbDemoContext();
            var datas = from p in ctx.TProducts
                        select p;
            return View(datas);
        }
        public IActionResult AddToCart(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            ViewBag.FID = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(CAddToCartViewModel vm)
        {
            DbDemoContext ctx = new DbDemoContext();
            TProduct prod = ctx.TProducts.FirstOrDefault(p => p.FId == vm.txtFId);
            if (prod != null)
            {
                string json = "";
                List<CShoppingCartItem> cart = null;
                if (HttpContext.Session.Keys.Contains(CDictionary.SK_PURCHASED_PRODUCTS_LIST))
                {
                    json = HttpContext.Session.GetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST);
                    cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
                }
                else
                    cart = new List<CShoppingCartItem>();
                CShoppingCartItem item = new CShoppingCartItem();
                item.price = (decimal)prod.FPrice;
                item.count = vm.txtCount;
                item.productId = vm.txtFId;
                item.Product = prod;
                cart.Add(item);
                json=JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST, json);
            }
            return RedirectToAction("List");
        }


    }
}
