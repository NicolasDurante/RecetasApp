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
    [Migration("20190427212605_InitialDb")]
    partial class InitialDb
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

                    b.Property<string>("Categoria");

                    b.Property<bool>("Comentarios");

                    b.Property<string>("Descripcion");

                    b.Property<string>("Dificultad");

                    b.Property<string>("ImagenUrl");

                    b.Property<string>("Ingredientes");

                    b.Property<string>("MedidaIngredientes");

                    b.Property<string>("Nombre");

                    b.Property<int>("NumIngredientes");

                    b.Property<string>("Observaciones");

                    b.Property<string>("Pasos");

                    b.Property<DateTime>("PublicadaEn");

                    b.Property<int>("Raciones");

                    b.Property<string>("Region");

                    b.Property<double>("Stock");

                    b.Property<string>("Temporada");

                    b.Property<string>("Tiempo");

                    b.Property<string>("UrlVideo");

                    b.HasKey("Id");

                    b.ToTable("Recetas");
                });
#pragma warning restore 612, 618
        }
    }
}
