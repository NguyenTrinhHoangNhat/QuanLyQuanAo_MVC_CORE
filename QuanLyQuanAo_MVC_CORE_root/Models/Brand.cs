using System;
using System.Collections.Generic;

namespace QuanLyQuanAo_MVC_CORE.Models;

public partial class Brand 
{
    public string Id { get; set; } = null!;

    public string? BrandName { get; set; }

    public string? ImgUrl { get; set; }

    public string? ImgName { get; set; }

    public int? IsDelete { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
