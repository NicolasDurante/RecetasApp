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
    [Migration("20190427224519_ModifyRecetas")]
    partial class ModifyRecetas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecetasApp.Web.Data.Entities.Receta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .IsRequired();

                    b.Property<bool>("Comentarios");

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<string>("Dificultad")
                        .IsRequired();

                    b.Property<string>("ImagenUrl");

                    b.Property<string>("Ingredientes")
                        .IsRequired();

                    b.Property<string>("MedidaIngredientes")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("NumIngredientes");

                    b.Property<string>("Observaciones");

                    b.Property<string>("Pasos")
                        .IsRequired();

                    b.Property<DateTime>("PublicadaEn");

                    b.Property<int>("Raciones");

                    b.Property<string>("Region");

                    b.Property<double>("Stock");

                    b.Property<string>("Temporada");

                    b.Property<string>("Tiempo")
                        .IsRequired();

                    b.Property<string>("UrlVideo");

                    b.HasKey("Id");

                    b.ToTable("Recetas");
                });
#pragma warning restore 612, 618
        }
    }
}
