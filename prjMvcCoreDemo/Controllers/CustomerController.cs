using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;

namespace prjMvcCoreDemo.Controllers
{
    public class CustomerController : SuperController
    {
        public IActionResult List(CKeywordViewModel vm)
        {
            DbDemoContext context = new DbDemoContext();
            IEnumerable<TCustomer> datas = null;
            if(vm.txtKeyword ==null)
                datas = from t in context.TCustomers
                        select t;
            else
                datas = context.TCustomers.Where(t => t.FName.ToUpper().Contains(vm.txtKeyword.ToUpper())
                || t.FPhone.ToUpper().Contains(vm.txtKeyword.ToUpper())
                || t.FEmail.ToUpper().Contains(vm.txtKeyword.ToUpper())
                || t.FAddress.ToUpper().Contains(vm.txtKeyword.ToUpper())
                );
            return View(datas);
        }
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(TCustomer c)
        {
            DbDemoContext ctx = new DbDemoContext();
            ctx.TCustomers.Add(c);
            ctx.SaveChanges();

            return RedirectToAction("List");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                DbDemoContext ctx = new DbDemoContext();
                TCustomer pro = ctx.TCustomers.FirstOrDefault(p => p.Fid == id);
                if (pro != null)
                {
                    ctx.TCustomers.Remove(pro);
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
            TCustomer cust = ctx.TCustomers.FirstOrDefault(p => p.Fid == id);
            if (cust == null)
                return RedirectToAction("List");
            return View(cust);
        }
        [HttpPost]
        public IActionResult Edit(TCustomer pln)
        {
            DbDemoContext ctx = new DbDemoContext();
            TCustomer cust = ctx.TCustomers.FirstOrDefault(p => p.Fid == pln.Fid);
            if (cust != null)
            {
                cust.FName = pln.FName;
                cust.FPhone = pln.FPhone;
                cust.FEmail = pln.FEmail;
                cust.FAddress = pln.FAddress;
                cust.FPassword = pln.FPassword;
                ctx.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
