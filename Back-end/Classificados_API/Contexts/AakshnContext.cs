using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Classificados_API.Domains;

#nullable disable

namespace Classificados_API.Contexts
{
    public partial class AakshnContext : DbContext
    {
        public AakshnContext()
        {
        }

        public AakshnContext(DbContextOptions<AakshnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Classificado> Classificados { get; set; }
        public virtual DbSet<ImagemBanco> ImagemBancos { get; set; }
        public virtual DbSet<Nicho> Nichos { get; set; }
        public virtual DbSet<Oferta> Ofertas { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoClassificado> TipoClassificados { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
<<<<<<< HEAD
                //optionsBuilder.UseSqlServer("server=CYBERNOTE-02\\SQLEXPRESS; database=Classificados_2; user Id=sa; pwd=Senai@132;");

                //maquina joao
                //optionsBuilder.UseSqlServer("server=DESKTOP-L3Q203S\\SQLEXPRESS; database=Classificados_2; user Id=sa; pwd=senai@132;");

                //Maquina Vitor
                optionsBuilder.UseSqlServer("server=DESKTOP-RR2ANFV\\SQLEXPRESS; database=Classificados_2; user Id=sa; pwd=Senai@132;");
=======
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-L3Q203S\\SQLEXPRESS; database=Classificados_2; user Id=sa; pwd=senai@132;");
>>>>>>> 52add0628feaeaa643943780d74e05c834186725
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240C7014FB6A");

                entity.HasIndex(e => e.Categoria1, "UQ__Categori__08015F8B974D5401")
                    .IsUnique();

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Categoria1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Categoria");

                entity.Property(e => e.IdNicho).HasColumnName("idNicho");

                entity.HasOne(d => d.IdNichoNavigation)
                    .WithMany(p => p.Categoria)
                    .HasForeignKey(d => d.IdNicho)
                    .HasConstraintName("FK__Categoria__idNic__403A8C7D");
            });

            modelBuilder.Entity<Classificado>(entity =>
            {
                entity.HasKey(e => e.IdClassificado)
                    .HasName("PK__Classifi__2170C53BCD3BDDF0");

                entity.Property(e => e.IdClassificado).HasColumnName("idClassificado");

                entity.Property(e => e.DataCricao).HasColumnType("datetime");

                entity.Property(e => e.DataExpiracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Classificados)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Classific__idSit__4BAC3F29");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Classificados)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Classific__idUsu__4AB81AF0");
            });

            modelBuilder.Entity<ImagemBanco>(entity =>
            {
                entity.HasKey(e => e.IdImg)
                    .HasName("PK__ImagemBa__3C3EAB5ACBFACCCD");

                entity.ToTable("ImagemBanco");

                entity.Property(e => e.IdImg).HasColumnName("idImg");

                entity.Property(e => e.Binario).IsRequired();

                entity.Property(e => e.IdClassificado).HasColumnName("idClassificado");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mimeType");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClassificadoNavigation)
                    .WithMany(p => p.ImagemBancos)
                    .HasForeignKey(d => d.IdClassificado)
                    .HasConstraintName("FK__ImagemBan__idCla__5441852A");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ImagemBancos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__ImagemBan__idUsu__534D60F1");
            });

            modelBuilder.Entity<Nicho>(entity =>
            {
                entity.HasKey(e => e.IdNicho)
                    .HasName("PK__Nichos__98EA600F0D0FBB19");

                entity.HasIndex(e => e.Nicho1, "UQ__Nichos__145CAB4ADB084260")
                    .IsUnique();

                entity.Property(e => e.IdNicho)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idNicho");

                entity.Property(e => e.Nicho1)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Nicho");
            });

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasKey(e => e.IdOfertas)
                    .HasName("PK__Ofertas__BB0EE9346553AC67");

                entity.Property(e => e.IdOfertas).HasColumnName("idOfertas");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.IdClassificado).HasColumnName("idClassificado");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdClassificadoNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdClassificado)
                    .HasConstraintName("FK__Ofertas__idClass__4F7CD00D");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Ofertas__idSitua__5070F446");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Ofertas__idUsuar__4E88ABD4");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__Situacao__12AFD1975425583E");

                entity.ToTable("Situacao");

                entity.HasIndex(e => e.Situacao1, "UQ__Situacao__AB931555AC523F44")
                    .IsUnique();

                entity.Property(e => e.IdSituacao)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSituacao");

                entity.Property(e => e.Situacao1)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Situacao");
            });

            modelBuilder.Entity<TipoClassificado>(entity =>
            {
                entity.HasKey(e => e.IdTipoClassificados)
                    .HasName("PK__TipoClas__5AC132FDDB87B948");

                entity.HasIndex(e => e.Tipo, "UQ__TipoClas__8E762CB4357A11DE")
                    .IsUnique();

                entity.Property(e => e.IdTipoClassificados)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoClassificados");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF1E6B4790");

                entity.HasIndex(e => e.TipoUsuario1, "UQ__TipoUsua__52F7E3AACA0EEB7E")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TipoUsuario")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A6B7E59E34");

                entity.HasIndex(e => e.Telefone, "UQ__Usuarios__4EC504B63134A5B4")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534ABB6BCDC")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Ddd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DDD");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nome)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__idTipo__47DBAE45");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
