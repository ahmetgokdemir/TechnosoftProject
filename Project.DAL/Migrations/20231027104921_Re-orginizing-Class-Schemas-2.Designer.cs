﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.DAL.Context;

#nullable disable

namespace Project.DAL.Migrations
{
    [DbContext(typeof(TechnosoftProjectContext))]
    [Migration("20231027104921_Re-orginizing-Class-Schemas-2")]
    partial class ReorginizingClassSchemas2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Rol Adı");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("AccessibleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("Şehir");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<short>("IsConfirmedAccount")
                        .HasColumnType("smallint")
                        .HasColumnName("Onay Durumu");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Kullanıcı Resim");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Kullanıcı Adı");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Blog", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DataStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.CategoryofFood", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("ID"));

                    b.Property<string>("CategoryName_of_Foods")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("Kategori Ad");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.HasKey("ID");

                    b.ToTable("Kategoriler", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Coupon", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CouponExpireDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("Son Kullanım Tarihi");

                    b.Property<string>("CouponName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("KuponID");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.HasKey("ID");

                    b.ToTable("Kuponlar", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Food", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<string>("Food_Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("Yemek Ad");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.HasKey("ID");

                    b.ToTable("Yemekler", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Models.ImageofFood", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<string>("Food_Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Yemek Resim");

                    b.Property<bool>("IsProfile")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.Property<short>("UserFoodJunctionID")
                        .HasColumnType("smallint")
                        .HasColumnName("Kullanici_Yemek_ID");

                    b.HasKey("ID");

                    b.HasIndex("UserFoodJunctionID");

                    b.ToTable("Yemek_Resimleri", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Menu", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("ID"));

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<string>("Menu_Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("Menu Ad");

                    b.Property<short>("Menu_Status")
                        .HasColumnType("smallint")
                        .HasColumnName("Menu Durum");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.Property<Guid>("User_AccessibleID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("AppUserId");

                    b.ToTable("Menuler", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Menu_UserFoodJunction", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("ID"));

                    b.Property<string>("CategoryName_of_Foods")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("Kategori Ad");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<short>("MenuID")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.Property<short>("UserFoodJunctionID")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("MenuID");

                    b.HasIndex("UserFoodJunctionID");

                    b.ToTable("Kullanici_Menu_Detayi", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Models.UserCategoryJunction", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("ID"));

                    b.Property<Guid>("AccessibleID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Kullanici_ID");

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("CategoryofFoodID")
                        .HasColumnType("smallint")
                        .HasColumnName("Kategori_ID");

                    b.Property<string>("CategoryofFood_Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Kategori Açıklama");

                    b.Property<string>("CategoryofFood_Picture")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Kategori Resim");

                    b.Property<short>("CategoryofFood_Status")
                        .HasColumnType("smallint")
                        .HasColumnName("Kategori Mevcudiyet Durum");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.HasKey("ID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CategoryofFoodID");

                    b.ToTable("Kullanici_Kategori_Detayi", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Models.UserFoodJunction", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("ID"));

                    b.Property<Guid>("AccessibleID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Kullanici_ID");

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Oluşturulma Tarihi");

                    b.Property<short>("DataStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("Crud Durum");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Silinme Tarihi");

                    b.Property<short>("FoodID")
                        .HasColumnType("smallint")
                        .HasColumnName("Yemek_ID");

                    b.Property<string>("Food_Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Yemek Açıklama");

                    b.Property<string>("Food_Picture")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Yemek Resim");

                    b.Property<decimal>("Food_Price")
                        .HasColumnType("smallmoney")
                        .HasColumnName("Yemek Fiyat");

                    b.Property<short>("Food_Status")
                        .HasColumnType("smallint")
                        .HasColumnName("Yemek Mevcudiyet Durum");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Güncelleme Tarihi");

                    b.HasKey("ID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("FoodID");

                    b.ToTable("Kullanici_Yemek_Detayi", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppRoleClaim", b =>
                {
                    b.HasOne("Project.ENTITIES.Identity_Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppUserClaim", b =>
                {
                    b.HasOne("Project.ENTITIES.Identity_Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppUserLogin", b =>
                {
                    b.HasOne("Project.ENTITIES.Identity_Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppUserRole", b =>
                {
                    b.HasOne("Project.ENTITIES.Identity_Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.ENTITIES.Identity_Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppUserToken", b =>
                {
                    b.HasOne("Project.ENTITIES.Identity_Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project.ENTITIES.Models.ImageofFood", b =>
                {
                    b.HasOne("Project.ENTITIES.Models.UserFoodJunction", "UserFoodJunction")
                        .WithMany("ImageofFoods")
                        .HasForeignKey("UserFoodJunctionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserFoodJunction");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Menu", b =>
                {
                    b.HasOne("Project.ENTITIES.Identity_Models.AppUser", "AppUser")
                        .WithMany("Menus")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Menu_UserFoodJunction", b =>
                {
                    b.HasOne("Project.ENTITIES.Models.Menu", "Menu")
                        .WithMany("Menu_UserFoodJunctions")
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.ENTITIES.Models.UserFoodJunction", "UserFoodJunction")
                        .WithMany("Menu_UserFoodJunctions")
                        .HasForeignKey("UserFoodJunctionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("UserFoodJunction");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.UserCategoryJunction", b =>
                {
                    b.HasOne("Project.ENTITIES.Identity_Models.AppUser", "AppUser")
                        .WithMany("UserCategoryJunctions")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.ENTITIES.Models.CategoryofFood", "CategoryofFood")
                        .WithMany("UserCategoryJunctions")
                        .HasForeignKey("CategoryofFoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("CategoryofFood");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.UserFoodJunction", b =>
                {
                    b.HasOne("Project.ENTITIES.Identity_Models.AppUser", "AppUser")
                        .WithMany("UserFoodJunctions")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.ENTITIES.Models.Food", "Food")
                        .WithMany("UserFoodJunctions")
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("Project.ENTITIES.Identity_Models.AppUser", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("UserCategoryJunctions");

                    b.Navigation("UserFoodJunctions");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.CategoryofFood", b =>
                {
                    b.Navigation("UserCategoryJunctions");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Food", b =>
                {
                    b.Navigation("UserFoodJunctions");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Menu", b =>
                {
                    b.Navigation("Menu_UserFoodJunctions");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.UserFoodJunction", b =>
                {
                    b.Navigation("ImageofFoods");

                    b.Navigation("Menu_UserFoodJunctions");
                });
#pragma warning restore 612, 618
        }
    }
}
