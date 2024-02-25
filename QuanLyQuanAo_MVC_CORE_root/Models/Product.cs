using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyQuanAo_MVC_CORE.Models;

public partial class Product
{
    public string Id { get; set; } = null!;

    [Required(ErrorMessage = "Tên sản phẩm không được để trống")] 
    public string? ProductName { get; set; }
[Required(ErrorMessage = "Sô lượng không được để trống")] 
    public int? Amout { get; set; }

    public int? NumberLove { get; set; }
[Required(ErrorMessage = "Mô tả không được để trống")] 
    public string? Description { get; set; }

[Required(ErrorMessage = "Danh sách loại size không được để trống")] 
    public string? SizeList { get; set; }
[Required(ErrorMessage = "Danh sách màu  không được để trống")] 
    public string? ColorList { get; set; }

    public string? ImgUrl { get; set; }

    public string? ImgName { get; set; }

[Required(ErrorMessage = "Giá không được để trống")] 
    public double? Price { get; set; }

    public double? Discount { get; set; }

    public string? IdBrand { get; set; }

    public string? IdProductTypes { get; set; }

    public int? IsDelete { get; set; }

    public virtual Brand? IdBrandNavigation { get; set; }

    public virtual ProductType? IdProductTypesNavigation { get; set; }
}
