﻿// <auto-generated />
using Amazon.Purchases.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Amazon.Purchases.Migrations
{
    [DbContext(typeof(PurchaseContext))]
    [Migration("20210327144500_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Amazon.Purchases.Model.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("Amazon.Purchases.Model.PurchaseProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductValue")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseProduct");
                });

            modelBuilder.Entity("Amazon.Purchases.Model.Wish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Wish");
                });

            modelBuilder.Entity("Amazon.Purchases.Model.WishItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("WishId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WishId");

                    b.ToTable("WishItem");
                });

            modelBuilder.Entity("Amazon.Purchases.Model.PurchaseProduct", b =>
                {
                    b.HasOne("Amazon.Purchases.Model.Purchase", "Purchase")
                        .WithMany("PurchaseProduct")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Amazon.Purchases.Model.WishItem", b =>
                {
                    b.HasOne("Amazon.Purchases.Model.Wish", "Wish")
                        .WithMany("WishItem")
                        .HasForeignKey("WishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
