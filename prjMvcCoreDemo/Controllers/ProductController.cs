using Microsoft.AspNetCore.Mvc;
using prjMauiDemo.NewFolder2;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;

namespace prjMvcCoreDemo.Controllers
{
    public class ProductController : SuperController
    {
        private IWebHostEnvironment _enviro = null;

        public ProductController(IWebHostEnvironment p)
        {
            _enviro = p;
        }
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
            CProductWrap prodWrap = new CProductWrap();
            prodWrap.product = prod;
            return View(prodWrap);
        }
        [HttpPost]
        public IActionResult Edit(CProductWrap pln)
        {
            DbDemoContext ctx = new DbDemoContext();
            TProduct prod = ctx.TProducts.FirstOrDefault(p => p.FId == pln.FId);
            if (prod != null)
            {
                if(pln.photo != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg"; //Guid建立亂數，可避免存放進去的照片出現相同的檔名
                    prod.FImagePath = photoName; //放到我們資料庫中ImagePath 做為路徑
                    //這段則是mvcCore最大的不同，改使用CopyTo(),裡面再用FileStream(照片的路徑, 如果找不到就新增)
                    pln.photo.CopyTo(new FileStream(
                        _enviro.WebRootPath + "/images/" + photoName, FileMode.Create));//WebRootPath 可以幫我們導到wwwroot
                }

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
