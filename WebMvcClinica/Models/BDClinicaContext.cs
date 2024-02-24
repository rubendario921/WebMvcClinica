using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebMvcClinica.Models;

namespace WebMvcClinica.Models
{
    public partial class BDClinicaContext : DbContext
    {
        public BDClinicaContext()
        {
        }

        public BDClinicaContext(DbContextOptions<BDClinicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditorium> Auditoria { get; set; } = null!;
        public virtual DbSet<EmpEsp> EmpEsps { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Especialidade> Especialidades { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Clinica");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.HasKey(e => e.AudiId);

                entity.ToTable("auditoria");

                entity.Property(e => e.AudiId).HasColumnName("audi_id");

                entity.Property(e => e.AudiCodRegistro).HasColumnName("audi_cod_registro");

                entity.Property(e => e.AudiEstado)
                    .HasMaxLength(1)
                    .HasColumnName("audi_estado");

                entity.Property(e => e.AudiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("audi_fecha");

                entity.Property(e => e.AudiTipo)
                    .HasMaxLength(1)
                    .HasColumnName("audi_tipo")
                    .IsFixedLength();

                entity.Property(e => e.AudiUsuario)
                    .HasMaxLength(50)
                    .HasColumnName("audi_usuario");
            });

            modelBuilder.Entity<EmpEsp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Emp_Esp");

                entity.Property(e => e.EmpleId).HasColumnName("emple_id");

                entity.Property(e => e.EspId).HasColumnName("esp_id");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.EmpleId);

                entity.Property(e => e.EmpleId).HasColumnName("emple_id");

                entity.Property(e => e.EmpleAdd)
                    .HasColumnType("datetime")
                    .HasColumnName("emple_add");

                entity.Property(e => e.EmpleAndress)
                    .HasMaxLength(200)
                    .HasColumnName("emple_andress")
                    .IsFixedLength();

                entity.Property(e => e.EmpleDatebrithay)
                    .HasColumnType("date")
                    .HasColumnName("emple_datebrithay");

                entity.Property(e => e.EmpleDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("emple_delete");

                entity.Property(e => e.EmpleEmail)
                    .HasMaxLength(200)
                    .HasColumnName("emple_email")
                    .IsFixedLength();

                entity.Property(e => e.EmpleGenero)
                    .HasMaxLength(1)
                    .HasColumnName("emple_genero")
                    .IsFixedLength();

                entity.Property(e => e.EmpleIdentify)
                    .HasMaxLength(10)
                    .HasColumnName("emple_identify")
                    .IsFixedLength();

                entity.Property(e => e.EmpleLastname)
                    .HasMaxLength(100)
                    .HasColumnName("emple_lastname")
                    .IsFixedLength();

                entity.Property(e => e.EmpleName)
                    .HasMaxLength(100)
                    .HasColumnName("emple_name")
                    .IsFixedLength();

                entity.Property(e => e.EmplePhone)
                    .HasMaxLength(13)
                    .HasColumnName("emple_phone")
                    .IsFixedLength();

                entity.Property(e => e.EmpleStatus)
                    .HasMaxLength(1)
                    .HasColumnName("emple_status")
                    .IsFixedLength();

                entity.Property(e => e.EmpleUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("emple_update");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.EspId);

                entity.Property(e => e.EspId).HasColumnName("esp_id");

                entity.Property(e => e.EspAdd)
                    .HasColumnType("datetime")
                    .HasColumnName("esp_add");

                entity.Property(e => e.EspDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("esp_delete");

                entity.Property(e => e.EspDescription)
                    .HasMaxLength(100)
                    .HasColumnName("esp_description")
                    .IsFixedLength();

                entity.Property(e => e.EspName)
                    .HasMaxLength(50)
                    .HasColumnName("esp_name")
                    .IsFixedLength();

                entity.Property(e => e.EspStatus)
                    .HasMaxLength(1)
                    .HasColumnName("esp_status")
                    .IsFixedLength();

                entity.Property(e => e.EspUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("esp_update");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.RolDetails)
                    .HasMaxLength(50)
                    .HasColumnName("rol_details");

                entity.Property(e => e.RolStatus)
                    .HasMaxLength(1)
                    .HasColumnName("rol_status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsuId);

                entity.Property(e => e.UsuId).HasColumnName("usu_id");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.UsuAdd)
                    .HasColumnType("datetime")
                    .HasColumnName("usu_add");

                entity.Property(e => e.UsuDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("usu_delete");

                entity.Property(e => e.UsuEmail)
                    .HasMaxLength(100)
                    .HasColumnName("usu_email");

                entity.Property(e => e.UsuIntentos).HasColumnName("usu_intentos");

                entity.Property(e => e.UsuLastname)
                    .HasMaxLength(100)
                    .HasColumnName("usu_lastname");

                entity.Property(e => e.UsuName)
                    .HasMaxLength(100)
                    .HasColumnName("usu_name");

                entity.Property(e => e.UsuPassword)
                    .HasMaxLength(100)
                    .HasColumnName("usu_password");

                entity.Property(e => e.UsuPerfil).HasColumnName("usu_perfil");

                entity.Property(e => e.UsuStatus)
                    .HasMaxLength(1)
                    .HasColumnName("usu_status");

                entity.Property(e => e.UsuSueldo)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("usu_sueldo");

                entity.Property(e => e.UsuUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("usu_update");

                entity.Property(e => e.UsuUser)
                    .HasMaxLength(100)
                    .HasColumnName("usu_user");

                entity.Property(e => e.UsuImage)
                    .HasColumnType("varbinary(max)")
                    .HasColumnName("usu_image");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
