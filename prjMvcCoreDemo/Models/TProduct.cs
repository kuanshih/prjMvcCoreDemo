using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace prjMvcCoreDemo.Models;

public partial class TProduct
{
    public int FId { get; set; }
    [DisplayName("商品名稱")]
    public string? FName { get; set; }
    [DisplayName("商品庫存")]
    public int? FQty { get; set; }
    [DisplayName("商品成本")]
    public decimal? FCost { get; set; }
    [DisplayName("商品單價")]
    public decimal? FPrice { get; set; }

    public string? FImagePath { get; set; }
}
