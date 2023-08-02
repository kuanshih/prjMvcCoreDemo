using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAPIDemoApp
{
    internal class TProduct
    {
        public int fId { get; set; }
        [DisplayName("商品名稱")]
        public string fName { get; set; }
        [DisplayName("商品庫存")]
        public int? fQty { get; set; }
        [DisplayName("商品成本")]
        public decimal? fCost { get; set; }
        [DisplayName("商品單價")]
        public decimal? fPrice { get; set; }

    }
}
