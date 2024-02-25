using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyQuanAo_MVC_CORE.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartDetail> CartDetails { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<OrderUser> OrderUsers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brand__3213E83F8ADA9618");

            entity.ToTable("brand");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .HasColumnName("brandName");
            entity.Property(e => e.ImgName)
                .HasMaxLength(100)
                .HasColumnName("imgName");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(255)
                .HasColumnName("imgUrl");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3213E83F024A81D4");

            entity.ToTable("Cart");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.IsOrder).HasColumnName("isOrder");
            entity.Property(e => e.TotalProducts).HasColumnName("totalProducts");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Cart__userId__49C3F6B7");
        });

        modelBuilder.Entity<CartDetail>(entity =>
        {
            entity
                .HasKey(e => e.Id).HasName("PK__CartDeta__3213E83FC7F4B31B");
            entity.ToTable("CartDetail");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.IdCart)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idCart");
            entity.Property(e => e.IdProduct)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idProduct");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalMoney).HasColumnName("totalMoney");

            entity.HasOne(d => d.IdCartNavigation).WithMany()
                .HasForeignKey(d => d.IdCart)
                .HasConstraintName("FK__CartDetai__idCar__4BAC3F29");

            entity.HasOne(d => d.IdProductNavigation).WithMany()
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__CartDetai__idPro__4CA06362");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3213E83F90C55EA2");

            entity.ToTable("Discount");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CodeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codeName");
            entity.Property(e => e.IsPercent).HasColumnName("isPercent");
            entity.Property(e => e.NameDiscount)
                .HasMaxLength(100)
                .HasColumnName("nameDiscount");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<OrderUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderUse__3213E83F917BBC51");

            entity.ToTable("OrderUser");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.IdCart)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idCart");
            entity.Property(e => e.IdDiscount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idDiscount");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("orderDate");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.IdCartNavigation).WithMany(p => p.OrderUsers)
                .HasForeignKey(d => d.IdCart)
                .HasConstraintName("FK__OrderUser__idCar__534D60F1");

            entity.HasOne(d => d.IdDiscountNavigation).WithMany(p => p.OrderUsers)
                .HasForeignKey(d => d.IdDiscount)
                .HasConstraintName("FK__OrderUser__idDis__5441852A");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3213E83FABE75C78");

            entity.ToTable("Product");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Amout).HasColumnName("amout");
            entity.Property(e => e.ColorList)
                .HasMaxLength(255)
                .HasColumnName("colorList");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.IdBrand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idBrand");
            entity.Property(e => e.IdProductTypes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idProductTypes");
            entity.Property(e => e.ImgName)
                .HasMaxLength(100)
                .HasColumnName("imgName");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(255)
                .HasColumnName("imgUrl");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            entity.Property(e => e.NumberLove).HasColumnName("numberLove");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("productName");
            entity.Property(e => e.SizeList)
                .HasMaxLength(255)
                .HasColumnName("sizeList");

            entity.HasOne(d => d.IdBrandNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdBrand)
                .HasConstraintName("FK__Product__idBrand__44FF419A");

            entity.HasOne(d => d.IdProductTypesNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductTypes)
                .HasConstraintName("FK__Product__idProdu__45F365D3");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductT__3213E83FAA4FA0A9");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            entity.Property(e => e.ProductTypesName)
                .HasMaxLength(50)
                .HasColumnName("productTypesName");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3213E83FF31D22F2");

            entity.ToTable("Role");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83FF581A029");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AddressUser)
                .HasMaxLength(255)
                .HasColumnName("addressUser");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.ImgName)
                .HasMaxLength(100)
                .HasColumnName("imgName");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(255)
                .HasColumnName("imgUrl");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            entity.Property(e => e.Pass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.RoleId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("roleId");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__roleId__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
