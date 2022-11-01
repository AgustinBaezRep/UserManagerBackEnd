using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class UserManagerContext : DbContext
    {
        public UserManagerContext()
        {
        }

        public UserManagerContext(DbContextOptions<UserManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Actividad1)
                    .IsRequired()
                    .HasColumnName("actividad")
                    .HasMaxLength(50);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NombreUsuario)
                    .HasColumnName("nombre_usuario")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(250);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(250);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("correo_electronico")
                    .HasMaxLength(250);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fecha_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdPaisResidencia).HasColumnName("id_pais_residencia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(250);

                entity.Property(e => e.RecibirInformacion).HasColumnName("recibir_informacion");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.IdPaisResidenciaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPaisResidencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__id_pais__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
