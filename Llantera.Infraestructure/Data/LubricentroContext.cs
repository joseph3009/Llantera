using System;
using System.Collections.Generic;
using Llantera.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Llantera.Infraestructure.Data;

public partial class LubricentroContext : DbContext
{
    public LubricentroContext(DbContextOptions<LubricentroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulos> Articulos { get; set; }

    public virtual DbSet<CategoriasArticulos> CategoriasArticulos { get; set; }

    public virtual DbSet<CategoriasServicios> CategoriasServicios { get; set; }

    public virtual DbSet<Galeria> Galeria { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Articulo__3214EC271F10075E");

            entity.HasIndex(e => e.Slug, "UQ__Articulo__BC7B5FB6B886B473").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");
            entity.Property(e => e.Imagen).HasMaxLength(500);
            entity.Property(e => e.MetaDescripcion).HasMaxLength(500);
            entity.Property(e => e.MetaTitulo).HasMaxLength(250);
            entity.Property(e => e.Resumen).HasMaxLength(500);
            entity.Property(e => e.Slug).HasMaxLength(300);
            entity.Property(e => e.Titulo).HasMaxLength(250);

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.Idcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Articulos__IDCat__3A81B327");
        });

        modelBuilder.Entity<CategoriasArticulos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC27825D01AC");

            entity.HasIndex(e => e.Slug, "UQ__Categori__BC7B5FB6AE93F548").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Slug).HasMaxLength(150);
        });

        modelBuilder.Entity<CategoriasServicios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC27A0439BEC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Galeria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Galeria__3214EC275E55ED5E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Imagen).HasMaxLength(500);
            entity.Property(e => e.Titulo).HasMaxLength(200);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC271AEAF314");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Servicio__3214EC274464B623");

            entity.HasIndex(e => e.Slug, "UQ__Servicio__BC7B5FB667AB25B6").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.DescripcionCorta).HasMaxLength(500);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");
            entity.Property(e => e.Imagen).HasMaxLength(500);
            entity.Property(e => e.Slug).HasMaxLength(250);
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.Idcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Servicios__IDCat__30F848ED");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC27EB8C43E8");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contrasenna).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Idrol).HasColumnName("IDRol");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idrol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__IDRol__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
