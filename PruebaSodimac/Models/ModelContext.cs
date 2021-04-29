using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaSodimac.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Descuentosmovimiento> Descuentosmovimientos { get; set; }
        public virtual DbSet<Descuentosrepuesto> Descuentosrepuestos { get; set; }
        public virtual DbSet<Existenciarepuesto> Existenciarepuestos { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Movimientofactura> Movimientofacturas { get; set; }
        public virtual DbSet<Preciosrepuesto> Preciosrepuestos { get; set; }
        public virtual DbSet<Tercero> Terceros { get; set; }
        public virtual DbSet<Tiposervicio> Tiposervicios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=VENTAS;Password=ORACLE;Data Source=localhost:1521/PRUEBA;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("VENTAS")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Descuentosmovimiento>(entity =>
            {
                entity.HasKey(e => e.Rowiddescmovtos)
                    .HasName("DESCUENTOSMOVIMIENTOS_PK");

                entity.ToTable("DESCUENTOSMOVIMIENTOS");

                entity.Property(e => e.Rowiddescmovtos)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROWIDDESCMOVTOS");

                entity.Property(e => e.Rowiddescuento)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROWIDDESCUENTO");

                entity.Property(e => e.Rowidmovtosfact)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROWIDMOVTOSFACT");

                entity.Property(e => e.Tasa)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TASA");

                entity.Property(e => e.Valor)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VALOR");

                entity.HasOne(d => d.RowiddescuentoNavigation)
                    .WithMany(p => p.Descuentosmovimientos)
                    .HasForeignKey(d => d.Rowiddescuento)
                    .HasConstraintName("DESCUENTO");

                entity.HasOne(d => d.RowidmovtosfactNavigation)
                    .WithMany(p => p.Descuentosmovimientos)
                    .HasForeignKey(d => d.Rowidmovtosfact)
                    .HasConstraintName("MOVTO_FACT");
            });

            modelBuilder.Entity<Descuentosrepuesto>(entity =>
            {
                entity.HasKey(e => e.Rowiddescuentos)
                    .HasName("DESCUENTOSREPUESTOS_PK");

                entity.ToTable("DESCUENTOSREPUESTOS");

                entity.Property(e => e.Rowiddescuentos)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROWIDDESCUENTOS");

                entity.Property(e => e.Codrepuesto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CODREPUESTO");

                entity.Property(e => e.Fechavigencia)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAVIGENCIA");

                entity.Property(e => e.Porcentajedescuentos)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PORCENTAJEDESCUENTOS");

                entity.Property(e => e.Valordescuento)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VALORDESCUENTO");

                entity.HasOne(d => d.CodrepuestoNavigation)
                    .WithMany(p => p.Descuentosrepuestos)
                    .HasForeignKey(d => d.Codrepuesto)
                    .HasConstraintName("ITEM_DESCUENTO");
            });

            modelBuilder.Entity<Existenciarepuesto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EXISTENCIAREPUESTOS");

                entity.Property(e => e.Cantidadexistencia)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CANTIDADEXISTENCIA");

                entity.Property(e => e.Codrepuesto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CODREPUESTO");

                entity.HasOne(d => d.CodrepuestoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Codrepuesto)
                    .HasConstraintName("ITEM_EXISTENCIA");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.RowidFactura)
                    .HasName("ROWID_FACT");

                entity.ToTable("FACTURA");

                entity.Property(e => e.RowidFactura)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROWID_FACTURA");

                entity.Property(e => e.Consecutivo)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CONSECUTIVO");

                entity.Property(e => e.Documentocliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTOCLIENTE");

                entity.Property(e => e.Documentomecanico)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTOMECANICO");

                entity.Property(e => e.Tipodocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TIPODOCUMENTO");

                entity.HasOne(d => d.DocumentoclienteNavigation)
                    .WithMany(p => p.FacturaDocumentoclienteNavigations)
                    .HasForeignKey(d => d.Documentocliente)
                    .HasConstraintName("CLIENTE");

                entity.HasOne(d => d.DocumentomecanicoNavigation)
                    .WithMany(p => p.FacturaDocumentomecanicoNavigations)
                    .HasForeignKey(d => d.Documentomecanico)
                    .HasConstraintName("MECANICO");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.IdRepuesto)
                    .HasName("REPUESTOS_PK");

                entity.ToTable("ITEMS");

                entity.Property(e => e.IdRepuesto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ID_REPUESTO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Tipoitem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TIPOITEM")
                    .IsFixedLength(true);

                entity.Property(e => e.Tiposervicio)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TIPOSERVICIO");

                entity.HasOne(d => d.TiposervicioNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Tiposervicio)
                    .HasConstraintName("TIPOSERVICIO");
            });

            modelBuilder.Entity<Movimientofactura>(entity =>
            {
                entity.HasKey(e => e.Rowidmovimientofactura)
                    .HasName("MOVTOFACT");

                entity.ToTable("MOVIMIENTOFACTURA");

                entity.Property(e => e.Rowidmovimientofactura)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROWIDMOVIMIENTOFACTURA");

                entity.Property(e => e.Coditem)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CODITEM");

                entity.Property(e => e.Precio)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRECIO");

                entity.Property(e => e.Rowidfactura)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROWIDFACTURA");

                entity.Property(e => e.Totaldescuento)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALDESCUENTO");

                entity.Property(e => e.Totalimpuesto)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALIMPUESTO");

                entity.Property(e => e.Valorbruto)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VALORBRUTO");

                entity.Property(e => e.Valortotal)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VALORTOTAL");

                entity.HasOne(d => d.CoditemNavigation)
                    .WithMany(p => p.Movimientofacturas)
                    .HasForeignKey(d => d.Coditem)
                    .HasConstraintName("ITEM");

                entity.HasOne(d => d.RowidfacturaNavigation)
                    .WithMany(p => p.Movimientofacturas)
                    .HasForeignKey(d => d.Rowidfactura)
                    .HasConstraintName("FACTURA");
            });

            modelBuilder.Entity<Preciosrepuesto>(entity =>
            {
                entity.HasKey(e => e.Rowidprecios)
                    .HasName("PRECIOSREPUESTOS_PK");

                entity.ToTable("PRECIOSREPUESTOS");

                entity.Property(e => e.Rowidprecios)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROWIDPRECIOS");

                entity.Property(e => e.Codrepuesto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CODREPUESTO");

                entity.Property(e => e.Fechavigencia)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAVIGENCIA");

                entity.Property(e => e.Valor)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VALOR");

                entity.HasOne(d => d.CodrepuestoNavigation)
                    .WithMany(p => p.Preciosrepuestos)
                    .HasForeignKey(d => d.Codrepuesto)
                    .HasConstraintName("ITEM_PRECIO");
            });

            modelBuilder.Entity<Tercero>(entity =>
            {
                entity.HasKey(e => e.Documento)
                    .HasName("TERCEROS_PK");

                entity.ToTable("TERCEROS");

                entity.Property(e => e.Documento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTO");

                entity.Property(e => e.Celular)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CELULAR");

                entity.Property(e => e.Correoelectronico)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("CORREOELECTRONICO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Estado)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ESTADO");

                entity.Property(e => e.Primerapellido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PRIMERAPELLIDO");

                entity.Property(e => e.Primernombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PRIMERNOMBRE");

                entity.Property(e => e.Segundoapellido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SEGUNDOAPELLIDO");

                entity.Property(e => e.Segundonombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SEGUNDONOMBRE");

                entity.Property(e => e.Tipodocumento)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TIPODOCUMENTO")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Tiposervicio>(entity =>
            {
                entity.HasKey(e => e.Rowidtiposervicio)
                    .HasName("TIPOSERVICIO_PK");

                entity.ToTable("TIPOSERVICIO");

                entity.Property(e => e.Rowidtiposervicio)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROWIDTIPOSERVICIO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.HasSequence("ROIWID_PRECIO");

            modelBuilder.HasSequence("ROWID_CONSECUTIVO").IsCyclic();

            modelBuilder.HasSequence("ROWID_DESCUENTOS");

            modelBuilder.HasSequence("ROWID_FACTURA");

            modelBuilder.HasSequence("ROWID_MOVTODESC");

            modelBuilder.HasSequence("ROWID_TIPOSERVICIO");

            modelBuilder.HasSequence("ROWIDMOVTOFACT");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
