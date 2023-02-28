using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace highload_backend_v1;

public partial class PrContext : DbContext
{
    public PrContext()
    {
    }

    public PrContext(DbContextOptions<PrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersElement> OrdersElements { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=pr;Username=postgres;Password=19102000");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cart");

            entity.Property(e => e.Customer)
                .HasMaxLength(36)
                .HasColumnName("customer");
            entity.Property(e => e.Products)
                .HasMaxLength(36)
                .HasColumnName("products");

            entity.HasOne(d => d.CustomerNavigation).WithMany()
                .HasForeignKey(d => d.Customer)
                .HasConstraintName("cart_customer_fkey");

            entity.HasOne(d => d.ProductsNavigation).WithMany()
                .HasForeignKey(d => d.Products)
                .HasConstraintName("cart_products_fkey");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Customer)
                .HasMaxLength(36)
                .HasColumnName("customer");
            entity.Property(e => e.Description).HasColumnName("description");

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Customer)
                .HasConstraintName("orders_customer_fkey");
        });

        modelBuilder.Entity<OrdersElement>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("orders_elements");

            entity.Property(e => e.ElementId)
                .HasMaxLength(36)
                .HasColumnName("element_id");
            entity.Property(e => e.OrderId)
                .HasMaxLength(36)
                .HasColumnName("order_id");

            entity.HasOne(d => d.Element).WithMany()
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("orders_elements_element_id_fkey");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("orders_elements_order_id_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
