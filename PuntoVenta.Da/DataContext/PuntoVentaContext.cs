using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PuntoVenta.Models;

namespace PuntoVenta.Da.DataContext;

public partial class PuntoVentaContext : DbContext
{
    public PuntoVentaContext()
    {
    }

    public PuntoVentaContext(DbContextOptions<PuntoVentaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<ArticuloTiendum> ArticuloTienda { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteArticulo> ClienteArticulos { get; set; }

    public virtual DbSet<Tiendum> Tienda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.ArticuloId).HasName("PK__Articulo__C0D7258D686B2950");

            entity.Property(e => e.ArticuloId).HasColumnName("ArticuloID");
            entity.Property(e => e.Codigo).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ArticuloTiendum>(entity =>
        {
            entity.HasKey(e => new { e.ArticuloId, e.TiendaId }).HasName("PK__Articulo__1F1F69CFB22BEDD3");

            entity.Property(e => e.ArticuloId).HasColumnName("ArticuloID");
            entity.Property(e => e.TiendaId).HasColumnName("TiendaID");
            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.Articulo).WithMany(p => p.ArticuloTienda)
                .HasForeignKey(d => d.ArticuloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ArticuloT__Artic__3D5E1FD2");

            entity.HasOne(d => d.Tienda).WithMany(p => p.ArticuloTienda)
                .HasForeignKey(d => d.TiendaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ArticuloT__Tiend__3E52440B");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A770B84493");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<ClienteArticulo>(entity =>
        {
            entity.HasKey(e => new { e.ClienteId, e.ArticuloId }).HasName("PK__ClienteA__BDA6A2FFDCBBBE70");

            entity.ToTable("ClienteArticulo");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.ArticuloId).HasColumnName("ArticuloID");
            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.Articulo).WithMany(p => p.ClienteArticulos)
                .HasForeignKey(d => d.ArticuloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClienteAr__Artic__4222D4EF");

            entity.HasOne(d => d.Cliente).WithMany(p => p.ClienteArticulos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClienteAr__Clien__412EB0B6");
        });

        modelBuilder.Entity<Tiendum>(entity =>
        {
            entity.HasKey(e => e.TiendaId).HasName("PK__Tienda__FC84C42CD9AE2699");

            entity.Property(e => e.TiendaId).HasColumnName("TiendaID");
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Sucursal).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
