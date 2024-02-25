using System;
using System.Collections.Generic;

namespace QuanLyQuanAo_MVC_CORE.Models;

public partial class OrderUser
{
    public string Id { get; set; } = null!;

    public string? IdCart { get; set; }

    public string? IdDiscount { get; set; }

    public double? Total { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual Cart? IdCartNavigation { get; set; }

    public virtual Discount? IdDiscountNavigation { get; set; }
}
