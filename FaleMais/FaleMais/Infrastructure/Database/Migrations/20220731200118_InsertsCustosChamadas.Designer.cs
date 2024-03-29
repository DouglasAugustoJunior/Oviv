﻿// <auto-generated />
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaleMais.Migrations
{
    [DbContext(typeof(FaleMaisDbContext))]
    [Migration("20220731200118_InsertsCustosChamadas")]
    partial class InsertsCustosChamadas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("FaleMais.Domain.CustoChamada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataDelecao")
                        .HasColumnType("TEXT");

                    b.Property<int>("DestinoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrigemId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ValorPorMin")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DestinoId");

                    b.HasIndex("OrigemId");

                    b.ToTable("CustoChamada");
                });

            modelBuilder.Entity("FaleMais.Domain.DDD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataDelecao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DDD");
                });

            modelBuilder.Entity("FaleMais.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Autorizacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataDelecao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("FaleMais.Domain.CustoChamada", b =>
                {
                    b.HasOne("FaleMais.Domain.DDD", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FaleMais.Domain.DDD", "Origem")
                        .WithMany()
                        .HasForeignKey("OrigemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destino");

                    b.Navigation("Origem");
                });
#pragma warning restore 612, 618
        }
    }
}
