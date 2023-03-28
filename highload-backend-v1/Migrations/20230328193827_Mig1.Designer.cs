﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using highload_backend_v1;

#nullable disable

namespace highload_backend_v1.Migrations
{
    [DbContext(typeof(PrContext))]
    [Migration("20230328193827_Mig1")]
    partial class Mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("highload_backend_v1.Cart", b =>
                {
                    b.Property<string>("Customer")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("customer");

                    b.Property<string>("Products")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("products");

                    b.HasIndex("Customer");

                    b.HasIndex("Products");

                    b.ToTable("cart", (string)null);
                });

            modelBuilder.Entity("highload_backend_v1.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<string>("Customer")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("customer");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("orders_pkey");

                    b.HasIndex("Customer");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("highload_backend_v1.OrdersElement", b =>
                {
                    b.Property<string>("ElementId")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("element_id");

                    b.Property<string>("OrderId")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("order_id");

                    b.HasIndex("ElementId");

                    b.HasIndex("OrderId");

                    b.ToTable("orders_elements", (string)null);
                });

            modelBuilder.Entity("highload_backend_v1.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<int?>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int?>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("products_pkey");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("highload_backend_v1.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("users_pkey");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("highload_backend_v1.Cart", b =>
                {
                    b.HasOne("highload_backend_v1.User", "CustomerNavigation")
                        .WithMany()
                        .HasForeignKey("Customer")
                        .HasConstraintName("cart_customer_fkey");

                    b.HasOne("highload_backend_v1.Product", "ProductsNavigation")
                        .WithMany()
                        .HasForeignKey("Products")
                        .HasConstraintName("cart_products_fkey");

                    b.Navigation("CustomerNavigation");

                    b.Navigation("ProductsNavigation");
                });

            modelBuilder.Entity("highload_backend_v1.Order", b =>
                {
                    b.HasOne("highload_backend_v1.User", "CustomerNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("Customer")
                        .HasConstraintName("orders_customer_fkey");

                    b.Navigation("CustomerNavigation");
                });

            modelBuilder.Entity("highload_backend_v1.OrdersElement", b =>
                {
                    b.HasOne("highload_backend_v1.Product", "Element")
                        .WithMany()
                        .HasForeignKey("ElementId")
                        .HasConstraintName("orders_elements_element_id_fkey");

                    b.HasOne("highload_backend_v1.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .HasConstraintName("orders_elements_order_id_fkey");

                    b.Navigation("Element");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("highload_backend_v1.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
