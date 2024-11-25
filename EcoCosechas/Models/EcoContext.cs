using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EcoCosechas.Models;

public partial class EcoContext : DbContext
{
    public EcoContext()
    {
    }

    public EcoContext(DbContextOptions<EcoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Cotizacion> Cotizacions { get; set; }

    public virtual DbSet<Detalle> Detalles { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Favorito> Favoritos { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Listum> Lista { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Presentacion> Presentacions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<Subcategorium> Subcategoria { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<Unidad> Unidads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=Eco; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Sucursal).WithMany(p => p.AspNetUsers)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK_AspNetUsers_Sucursal");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Oferta)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Categoria)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Categoria_Empresa");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.ToTable("Ciudad");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Estado).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_Ciudad_Estado");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Cliente");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Cliente_Empresa");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.ToTable("Compra");

            entity.Property(e => e.Costo).HasColumnType("money");
            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.HasOne(d => d.Producto).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_Compra_Producto");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK_Compra_Proveedor");

            entity.HasOne(d => d.Unidad).WithMany(p => p.Compras)
                .HasForeignKey(d => d.UnidadId)
                .HasConstraintName("FK_Compra_Unidad");
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.ToTable("Cotizacion");

            entity.Property(e => e.Actualizacion).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("money");
            entity.Property(e => e.Unitario).HasColumnType("money");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Cotizacion_Empresa");

            entity.HasOne(d => d.Producto).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_Cotizacion_Producto");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK_Cotizacion_Proveedor");
        });

        modelBuilder.Entity<Detalle>(entity =>
        {
            entity.ToTable("Detalle");

            entity.Property(e => e.Precio).HasColumnType("money");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Detalles)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK_Detalle_Pedido");

            entity.HasOne(d => d.Presentacion).WithMany(p => p.Detalles)
                .HasForeignKey(d => d.PresentacionId)
                .HasConstraintName("FK_Detalle_Presentacion");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.ToTable("Empresa");

            entity.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Prefijo)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.ToTable("Estado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Pais).WithMany(p => p.Estados)
                .HasForeignKey(d => d.PaisId)
                .HasConstraintName("FK_Estado_Pais");
        });

        modelBuilder.Entity<Favorito>(entity =>
        {
            entity.ToTable("Favorito");

            entity.HasOne(d => d.Presentacion).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.PresentacionId)
                .HasConstraintName("FK_Favorito_Presentacion");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK_Favorito_Sucursal");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");

            entity.HasOne(d => d.Lista).WithMany(p => p.Items)
                .HasForeignKey(d => d.ListaId)
                .HasConstraintName("FK_Item_Lista");

            entity.HasOne(d => d.Presentacion).WithMany(p => p.Items)
                .HasForeignKey(d => d.PresentacionId)
                .HasConstraintName("FK_Item_Presentacion");
        });

        modelBuilder.Entity<Listum>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Lista)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK_Lista_Sucursal");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.ToTable("Marca");

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Marcas)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Marca_Empresa");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Pais)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Pais_Empresa");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.ToTable("Pedido");

            entity.Property(e => e.Cancelado).HasColumnType("datetime");
            entity.Property(e => e.Descuento).HasColumnType("money");
            entity.Property(e => e.Entrega).HasColumnType("datetime");
            entity.Property(e => e.Entregado).HasColumnType("datetime");
            entity.Property(e => e.Enviado).HasColumnType("datetime");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Subtotal).HasColumnType("money");
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK_Pedido_Sucursal");
        });

        modelBuilder.Entity<Presentacion>(entity =>
        {
            entity.ToTable("Presentacion");

            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sku)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Presentacions)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Presentacion_Empresa");

            entity.HasOne(d => d.Producto).WithMany(p => p.Presentacions)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_Presentacion_Producto");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Producto");

            entity.Property(e => e.Actualizacion).HasColumnType("datetime");
            entity.Property(e => e.Costo).HasColumnType("money");
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasComputedColumnSql("([Costo]*((1)+[Utilidad]))", true);

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .HasConstraintName("FK_Producto_Marca");

            entity.HasOne(d => d.Subcategoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.SubcategoriaId)
                .HasConstraintName("FK_Producto_Subcategoria");

            entity.HasOne(d => d.Unidad).WithMany(p => p.Productos)
                .HasForeignKey(d => d.UnidadId)
                .HasConstraintName("FK_Producto_Unidad");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.ToTable("Proveedor");

            entity.Property(e => e.Bodega)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Puesto)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.CiudadId)
                .HasConstraintName("FK_Proveedor_Ciudad");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Proveedor_Empresa");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.ToTable("Sede");

            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Sedes)
                .HasForeignKey(d => d.CiudadId)
                .HasConstraintName("FK_Sede_Ciudad");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Sedes)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Sede_Empresa");
        });

        modelBuilder.Entity<Subcategorium>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Subcategoria)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK_Subcategoria_Categoria");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.ToTable("Sucursal");

            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Contacto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.CiudadId)
                .HasConstraintName("FK_Sucursal_Ciudad");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Sucursal_Cliente");
        });

        modelBuilder.Entity<Unidad>(entity =>
        {
            entity.ToTable("Unidad");

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Unidads)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_Unidad_Empresa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
