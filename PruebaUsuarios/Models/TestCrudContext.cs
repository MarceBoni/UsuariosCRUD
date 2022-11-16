using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaUsuarios.Models
{
    public partial class TestCrudContext : DbContext
    {
        public TestCrudContext()
        {
        }

        public TestCrudContext(DbContextOptions<TestCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1LV2Q8B;Database=TestCrud;User ID=sa;Password=Sa1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.ToTable("tipoUsuario");

                entity.Property(e => e.NombreTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombreTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("apellido")
                    .IsFixedLength(true);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_tipoUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
