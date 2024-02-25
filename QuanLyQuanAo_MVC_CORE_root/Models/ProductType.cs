using System;
using System.Collections.Generic;

namespace QuanLyQuanAo_MVC_CORE.Models;

public partial class ProductType 
{
    public string Id { get; set; } = null!;

    public string? ProductTypesName { get; set; }

    public int? IsDelete { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
