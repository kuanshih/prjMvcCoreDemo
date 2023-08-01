using Microsoft.AspNetCore.Mvc;
using prjMauiDemo.NewFolder2;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;

namespace prjMvcCoreDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List(CKeywordViewModel vm)
        {
            DbDemoContext cxt = new DbDemoContext();
            IEnumerable<TProduct> datas = null;
            if (vm.txtKeyword == null)
                datas = from t in cxt.TProducts
                        select t;
            else
                datas = cxt.TProducts.Where(t => t.FName.ToUpper().Contains(vm.txtKeyword.ToUpper())
                );
            return View(datas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TProduct c)
        {
            DbDemoContext ctx = new DbDemoContext();
            ctx.TProducts.Add(c);
            ctx.SaveChanges();

            return RedirectToAction("List");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                DbDemoContext ctx = new DbDemoContext();
                TProduct prod = ctx.TProducts.FirstOrDefault(p => p.FId == id);
                if (prod != null)
                {
                    ctx.TProducts.Remove(prod);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            DbDemoContext ctx = new DbDemoContext();
            TProduct prod = ctx.TProducts.FirstOrDefault(p => p.FId == id);
            if (prod == null)
                return RedirectToAction("List");
            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(TProduct pln)
        {
            DbDemoContext ctx = new DbDemoContext();
            TProduct prod = ctx.TProducts.FirstOrDefault(p => p.FId == pln.FId);
            if (prod != null)
            {
                prod.FName = pln.FName;
                prod.FQty = pln.FQty;
                prod.FPrice = pln.FPrice;
                prod.FCost = pln.FCost;
                ctx.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }
}
