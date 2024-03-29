﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyQuanAo_MVC_CORE.Models;

#nullable disable

namespace QuanLyQuanAo_MVC_CORE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.Brand", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("BrandName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("brandName");

                    b.Property<string>("ImgName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("imgName");

                    b.Property<string>("ImgUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("imgUrl");

                    b.Property<int?>("IsDelete")
                        .HasColumnType("int")
                        .HasColumnName("isDelete");

                    b.HasKey("Id")
                        .HasName("PK__brand__3213E83F8ADA9618");

                    b.ToTable("brand", (string)null);
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.Cart", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int?>("IsOrder")
                        .HasColumnType("int")
                        .HasColumnName("isOrder");

                    b.Property<double?>("TotalProducts")
                        .HasColumnType("float")
                        .HasColumnName("totalProducts");

                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("userId");

                    b.HasKey("Id")
                        .HasName("PK__Cart__3213E83F024A81D4");

                    b.HasIndex("UserId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.CartDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("IdCart")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("idCart");

                    b.Property<string>("IdProduct")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("idProduct");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<double?>("TotalMoney")
                        .HasColumnType("float")
                        .HasColumnName("totalMoney");

                    b.HasKey("Id")
                        .HasName("PK__CartDeta__3213E83FC7F4B31B");

                    b.HasIndex("IdCart");

                    b.HasIndex("IdProduct");

                    b.ToTable("CartDetail", (string)null);
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.Discount", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("CodeName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("codeName");

                    b.Property<int?>("IsDelete")
                        .HasColumnType("int");

                    b.Property<int?>("IsPercent")
                        .HasColumnType("int")
                        .HasColumnName("isPercent");

                    b.Property<string>("NameDiscount")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nameDiscount");

                    b.Property<double?>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("PK__Discount__3213E83F90C55EA2");

                    b.ToTable("Discount", (string)null);
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.OrderUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("IdCart")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("idCart");

                    b.Property<string>("IdDiscount")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("idDiscount");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("date")
                        .HasColumnName("orderDate");

                    b.Property<double?>("Total")
                        .HasColumnType("float")
                        .HasColumnName("total");

                    b.HasKey("Id")
                        .HasName("PK__OrderUse__3213E83F917BBC51");

                    b.HasIndex("IdCart");

                    b.HasIndex("IdDiscount");

                    b.ToTable("OrderUser", (string)null);
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int?>("Amout")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("amout");

                    b.Property<string>("ColorList")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("colorList");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("description");

                    b.Property<double?>("Discount")
                        .HasColumnType("float")
                        .HasColumnName("discount");

                    b.Property<string>("IdBrand")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("idBrand");

                    b.Property<string>("IdProductTypes")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("idProductTypes");

                    b.Property<string>("ImgName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("imgName");

                    b.Property<string>("ImgUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("imgUrl");

                    b.Property<int?>("IsDelete")
                        .HasColumnType("int")
                        .HasColumnName("isDelete");

                    b.Property<int?>("NumberLove")
                        .HasColumnType("int")
                        .HasColumnName("numberLove");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("productName");

                    b.Property<string>("SizeList")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("sizeList");

                    b.HasKey("Id")
                        .HasName("PK__Product__3213E83FABE75C78");

                    b.HasIndex("IdBrand");

                    b.HasIndex("IdProductTypes");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.ProductType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int?>("IsDelete")
                        .HasColumnType("int")
                        .HasColumnName("isDelete");

                    b.Property<string>("ProductTypesName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("productTypesName");

                    b.HasKey("Id")
                        .HasName("PK__ProductT__3213E83FAA4FA0A9");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("roleName");

                    b.HasKey("Id")
                        .HasName("PK__Role__3213E83FF31D22F2");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("AddressUser")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("addressUser");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("ImgName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("imgName");

                    b.Property<string>("ImgUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("imgUrl");

                    b.Property<int?>("IsDelete")
                        .HasColumnType("int")
                        .HasColumnName("isDelete");

                    b.Property<string>("Pass")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("pass");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phoneNumber");

                    b.Property<string>("RoleId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("roleId");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PK__User__3213E83FF581A029");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.Cart", b =>
                {
                    b.HasOne("QuanLyQuanAo_MVC_CORE.Models.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Cart__userId__49C3F6B7");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.CartDetail", b =>
                {
                    b.HasOne("QuanLyQuanAo_MVC_CORE.Models.Cart", "IdCartNavigation")
                        .WithMany()
                        .HasForeignKey("IdCart")
                        .HasConstraintName("FK__CartDetai__idCar__4BAC3F29");

                    b.HasOne("QuanLyQuanAo_MVC_CORE.Models.Product", "IdProductNavigation")
                        .WithMany()
                        .HasForeignKey("IdProduct")
                        .HasConstraintName("FK__CartDetai__idPro__4CA06362");

                    b.Navigation("IdCartNavigation");

                    b.Navigation("IdProductNavigation");
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.OrderUser", b =>
                {
                    b.HasOne("QuanLyQuanAo_MVC_CORE.Models.Cart", "IdCartNavigation")
                        .WithMany("OrderUsers")
                        .HasForeignKey("IdCart")
                        .HasConstraintName("FK__OrderUser__idCar__534D60F1");

                    b.HasOne("QuanLyQuanAo_MVC_CORE.Models.Discount", "IdDiscountNavigation")
                        .WithMany("OrderUsers")
                        .HasForeignKey("IdDiscount")
                        .HasConstraintName("FK__OrderUser__idDis__5441852A");

                    b.Navigation("IdCartNavigation");

                    b.Navigation("IdDiscountNavigation");
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.Product", b =>
                {
                    b.HasOne("QuanLyQuanAo_MVC_CORE.Models.Brand", "IdBrandNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdBrand")
                        .HasConstraintName("FK__Product__idBrand__44FF419A");

                    b.HasOne("QuanLyQuanAo_MVC_CORE.Models.ProductType", "IdProductTypesNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdProductTypes")
                        .HasConstraintName("FK__Product__idProdu__45F365D3");

                    b.Navigation("IdBrandNavigation");

                    b.Navigation("IdProductTypesNavigation");
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.User", b =>
                {
                    b.HasOne("QuanLyQuanAo_MVC_CORE.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__User__roleId__3B75D760");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.Cart", b =>
                {
                    b.Navigation("OrderUsers");
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.Discount", b =>
                {
                    b.Navigation("OrderUsers");
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.ProductType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("QuanLyQuanAo_MVC_CORE.Models.User", b =>
                {
                    b.Navigation("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}
