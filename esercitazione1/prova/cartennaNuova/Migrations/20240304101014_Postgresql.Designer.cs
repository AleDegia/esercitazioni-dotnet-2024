﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace cartennaNuova.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20240304101014_Postgresql")]
    partial class Postgresql
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clienti");
                });

            modelBuilder.Entity("Ordine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProdottoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProdottoId");

                    b.ToTable("Ordini");
                });

            modelBuilder.Entity("Prodotto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Prezzo")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Prodotti");
                });

            modelBuilder.Entity("Ordine", b =>
                {
                    b.HasOne("Prodotto", "Prodotto")
                        .WithMany("Ordini")
                        .HasForeignKey("ProdottoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prodotto");
                });

            modelBuilder.Entity("Prodotto", b =>
                {
                    b.HasOne("Cliente", "Cliente")
                        .WithMany("Prodotti")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Navigation("Prodotti");
                });

            modelBuilder.Entity("Prodotto", b =>
                {
                    b.Navigation("Ordini");
                });
#pragma warning restore 612, 618
        }
    }
}
