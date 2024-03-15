﻿// <auto-generated />
using System;
using Kalorienzähler.Daten;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kalorienzähler.Migrations
{
    [DbContext(typeof(KalorienzählerContext))]
    [Migration("20240315093012_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Kalorienzähler.Model.Produkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gramm")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kalorien")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Produkte");
                });

            modelBuilder.Entity("Kalorienzähler.Model.Verbrauch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Menge")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Zeitpunkt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Verbrauche");
                });
#pragma warning restore 612, 618
        }
    }
}
