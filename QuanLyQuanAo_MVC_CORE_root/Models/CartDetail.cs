using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyQuanAo_MVC_CORE.Models;

public partial class CartDetail
{
    public string Id { get; set; } = null!;
    public string? IdCart { get; set; }
    public string? IdProduct { get; set; }

    public int? Quantity { get; set; }

    public double? TotalMoney { get; set; }

    public virtual Cart? IdCartNavigation { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
