using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace prjMvcCoreDemo.Models;

public partial class TCustomer
{
    public int Fid { get; set; }

    [DisplayName("姓名")]
    public string? FName { get; set; }
    [DisplayName("電話")]
    public string? FPhone { get; set; }
    [DisplayName("信箱")]
    public string? FEmail { get; set; }
    [DisplayName("地址")]
    public string? FAddress { get; set; }
    [DisplayName("密碼")]
    public string? FPassword { get; set; }
}
