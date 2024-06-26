﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class TitoContext : DbContext
{
    public TitoContext(DbContextOptions<TitoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Marca> Marca { get; set; }

    public virtual DbSet<Modelo> Modelo { get; set; }

    public virtual DbSet<Pedido> Pedido { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalle { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Marca_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, null, null, 9999999L, null, null);
            entity.Property(e => e.Nombre).IsRequired();
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Modelo_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, null, null, 999999L, null, null);
            entity.Property(e => e.Nombre).IsRequired();
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pedido_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, null, null, 99999L, null, null)
                .HasColumnName("id");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PedidoDetalle_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, null, null, 999999L, null, null)
                .HasColumnName("id");
            entity.Property(e => e.IdPedido).HasColumnName("idPedido");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoDetalle)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idPedido");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.PedidoDetalle)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idProducto");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Producto_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, null, null, 9999L, null, null);
            entity.Property(e => e.Descripcion).IsRequired();
            entity.Property(e => e.IdModelo).HasColumnName("idModelo");
            entity.Property(e => e.Nombre).IsRequired();

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idMarca");

            entity.HasOne(d => d.IdModeloNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdModelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idModelo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}