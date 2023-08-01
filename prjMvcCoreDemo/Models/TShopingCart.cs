using System;
using System.Collections.Generic;

namespace prjMvcCoreDemo.Models;

public partial class TShopingCart
{
    public int FId { get; set; }

    public string? FDate { get; set; }

    public int? FCustomerId { get; set; }

    public int? FProductId { get; set; }

    public int? FCount { get; set; }

    public decimal? FPrice { get; set; }
}
