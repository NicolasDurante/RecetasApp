﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecetasApp.Web.Data;

namespace RecetasApp.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190921231516_otromas")]
    partial class otromas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.CategoriaComida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria");

                    b.HasKey("Id");

                    b.ToTable("CategoriaComidas");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.CategoriaComidaReceta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaComidasId");

                    b.Property<int?>("RecetaId");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaComidasId");

                    b.HasIndex("RecetaId");

                    b.ToTable("CategoriaComidaRecetas");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentari");

                    b.Property<int?>("RecetaId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RecetaId");

                    b.HasIndex("UserId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ingredient");

                    b.HasKey("Id");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RecetaId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RecetaId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Medida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviacion")
                        .IsRequired();

                    b.Property<string>("Medid");

                    b.HasKey("Id");

                    b.ToTable("Medidas");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Observacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Observacio");

                    b.Property<int?>("RecetaId");

                    b.HasKey("Id");

                    b.HasIndex("RecetaId");

                    b.ToTable("Observacions");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.PasosReceta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Instrucciones");

                    b.Property<int>("NumPaso");

                    b.Property<int?>("RecetaId");

                    b.HasKey("Id");

                    b.HasIndex("RecetaId");

                    b.ToTable("PasosRecetas");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Receta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ActiComentarios");

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<string>("Dificultad")
                        .IsRequired();

                    b.Property<string>("ImagenUrl");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("NumLikes");

                    b.Property<int>("Raciones");

                    b.Property<int?>("RegionId");

                    b.Property<string>("Temporada");

                    b.Property<string>("Tiempo")
                        .IsRequired();

                    b.Property<string>("UrlVideo");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("UserId");

                    b.ToTable("Recetas");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.RecetaIngrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int?>("IngredientesId");

                    b.Property<int?>("MedidasId");

                    b.Property<int?>("RecetaId");

                    b.HasKey("Id");

                    b.HasIndex("IngredientesId");

                    b.HasIndex("MedidasId");

                    b.HasIndex("RecetaId");

                    b.ToTable("RecetaIngredientes");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomRegion");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RecetasApp.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RecetasApp.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecetasApp.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RecetasApp.Web.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.CategoriaComidaReceta", b =>
                {
                    b.HasOne("RecetasApp.Web.Data.Entities.CategoriaComida", "CategoriaComidas")
                        .WithMany("CategoriaComidaRecetas")
                        .HasForeignKey("CategoriaComidasId");

                    b.HasOne("RecetasApp.Web.Data.Entities.Receta", "Receta")
                        .WithMany("CategoriaComidaRecetas")
                        .HasForeignKey("RecetaId");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Comentario", b =>
                {
                    b.HasOne("RecetasApp.Web.Data.Entities.Receta", "Receta")
                        .WithMany("Comentarios")
                        .HasForeignKey("RecetaId");

                    b.HasOne("RecetasApp.Web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Like", b =>
                {
                    b.HasOne("RecetasApp.Web.Data.Entities.Receta", "Receta")
                        .WithMany("Likes")
                        .HasForeignKey("RecetaId");

                    b.HasOne("RecetasApp.Web.Data.Entities.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Observacion", b =>
                {
                    b.HasOne("RecetasApp.Web.Data.Entities.Receta", "Receta")
                        .WithMany("Observacions")
                        .HasForeignKey("RecetaId");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.PasosReceta", b =>
                {
                    b.HasOne("RecetasApp.Web.Data.Entities.Receta", "Receta")
                        .WithMany("PasosRecetas")
                        .HasForeignKey("RecetaId");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Receta", b =>
                {
                    b.HasOne("RecetasApp.Web.Data.Entities.Region", "Region")
                        .WithMany("Recetas")
                        .HasForeignKey("RegionId");

                    b.HasOne("RecetasApp.Web.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.RecetaIngrediente", b =>
                {
                    b.HasOne("RecetasApp.Web.Data.Entities.Ingrediente", "Ingredientes")
                        .WithMany("RecetaIngredientes")
                        .HasForeignKey("IngredientesId");

                    b.HasOne("RecetasApp.Web.Data.Entities.Medida", "Medidas")
                        .WithMany("RecetaIngredientes")
                        .HasForeignKey("MedidasId");

                    b.HasOne("RecetasApp.Web.Data.Entities.Receta", "Receta")
                        .WithMany("RecetaIngredientes")
                        .HasForeignKey("RecetaId");
                });
#pragma warning restore 612, 618
        }
    }
}
