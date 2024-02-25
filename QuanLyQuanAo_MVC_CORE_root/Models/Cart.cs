using System;
using System.Collections.Generic;

namespace QuanLyQuanAo_MVC_CORE.Models;

public partial class Cart
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public double? TotalProducts { get; set; }

    public int? IsOrder { get; set; }

    public virtual ICollection<OrderUser> OrderUsers { get; set; } = new List<OrderUser>();

    public virtual User? User { get; set; }
}
