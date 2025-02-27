﻿// <auto-generated />
using System;
using Final_Project_2._1.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Final_Project_2._1.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221030121838_DbVersion2")]
    partial class DbVersion2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Final_Project_2._1.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("codPostal")
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("localidade")
                        .HasColumnType("longtext");

                    b.Property<string>("morada")
                        .HasColumnType("longtext");

                    b.Property<int>("nif")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.Property<float>("saldoDisp")
                        .HasColumnType("float");

                    b.Property<int>("telefone")
                        .HasColumnType("int");

                    b.Property<DateTime>("validade")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Final_Project_2._1.Models.Movimento", b =>
                {
                    b.Property<int>("id_mov")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_hora")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("importancia")
                        .HasColumnType("float");

                    b.HasKey("id_mov");

                    b.HasIndex("ClienteId");

                    b.ToTable("Movimentos");
                });

            modelBuilder.Entity("Final_Project_2._1.Models.Movimento", b =>
                {
                    b.HasOne("Final_Project_2._1.Models.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
