using System;
using System.Collections.Generic;

namespace QuanLyQuanAo_MVC_CORE.Models;

public partial class Discount
{
    public string Id { get; set; } = null!;

    public string? NameDiscount { get; set; }

    public string? CodeName { get; set; }

    public int? IsPercent { get; set; }
    public int? IsDelete { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<OrderUser> OrderUsers { get; set; } = new List<OrderUser>();
}
