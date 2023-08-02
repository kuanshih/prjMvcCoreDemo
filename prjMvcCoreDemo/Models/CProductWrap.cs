using System.ComponentModel;

namespace prjMvcCoreDemo.Models
{
    public class CProductWrap
    {
        private TProduct _prod = null;

        public TProduct product
        {
            get { return _prod; }
            set { _prod = value; }
        }
        public CProductWrap()
        {
            _prod = new TProduct();
        }
        public int FId
        {
            get { return _prod.FId; }
            set { _prod.FId = value; }
        }
        [DisplayName("商品名稱")]
        public string? FName
        {
            get { return _prod.FName; }
            set { _prod.FName = value; }
        }
        [DisplayName("商品庫存")]
        public int? FQty
        {
            get { return _prod.FQty; }
            set { _prod.FQty = value; }
        }
        [DisplayName("商品成本")]
        public decimal? FCost
        {
            get { return _prod.FCost; }
            set { _prod.FCost = value; }
        }
        [DisplayName("商品單價")]
        public decimal? FPrice
        {
            get { return _prod.FPrice; }
            set { _prod.FPrice = value; }
        }

        public string? FImagePath
        {
            get { return _prod.FImagePath; }
            set { _prod.FImagePath = value; }
        }
        public IFormFile photo { get; set; }
    }
}
