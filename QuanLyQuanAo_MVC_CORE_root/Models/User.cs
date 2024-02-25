using System;
using System.Collections.Generic;

namespace QuanLyQuanAo_MVC_CORE.Models;

public partial class User 
{
    public string Id { get; set; } = null!; 

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Pass { get; set; }

    public string? RoleId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? AddressUser { get; set; }

    public string? ImgUrl { get; set; }

    public string? ImgName { get; set; }

    public int? IsDelete { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Role? Role { get; set; }
}
