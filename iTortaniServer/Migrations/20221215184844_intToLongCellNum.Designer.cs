﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iTortaniServer.Models.Spese;

#nullable disable

namespace iTortaniServer.Migrations
{
    [DbContext(typeof(SpeseContext))]
    [Migration("20221215184844_intToLongCellNum")]
    partial class intToLongCellNum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("iTortaniServer.Models.Spese.Spese", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CellNum")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CheckTortani")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataRitiro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Luogo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Ritirato")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Spese");
                });
#pragma warning restore 612, 618
        }
    }
}