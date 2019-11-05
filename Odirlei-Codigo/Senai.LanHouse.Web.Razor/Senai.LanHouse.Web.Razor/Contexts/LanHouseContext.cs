using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.LanHouse.Web.Razor.Domains
{
    public partial class LanHouseContext : DbContext
    {
        public LanHouseContext()
        {
        }

        public LanHouseContext(DbContextOptions<LanHouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RegistroDefeitos> RegistroDefeitos { get; set; }
        public virtual DbSet<TiposDefeitos> TiposDefeitos { get; set; }
        public virtual DbSet<TiposEquipamentos> TiposEquipamentos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SqlExpress01; Initial Catalog=odirlei_lanhouse_saep; user id=sa; pwd=info@132");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroDefeitos>(entity =>
            {
                entity.Property(e => e.DataChamado).HasColumnType("datetime");

                entity.Property(e => e.Descricao).HasColumnType("text");

                entity.HasOne(d => d.IdTipoDefeitoNavigation)
                    .WithMany(p => p.RegistroDefeitos)
                    .HasForeignKey(d => d.IdTipoDefeito)
                    .HasConstraintName("FK__RegistroD__IdTip__5441852A");

                entity.HasOne(d => d.IdTipoEquipamentoNavigation)
                    .WithMany(p => p.RegistroDefeitos)
                    .HasForeignKey(d => d.IdTipoEquipamento)
                    .HasConstraintName("FK__RegistroD__IdTip__534D60F1");
            });

            modelBuilder.Entity<TiposDefeitos>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TiposDef__7D8FE3B20F879C54")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposEquipamentos>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TiposEqu__7D8FE3B2767CC991")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D10534D859BFA2")
                    .IsUnique();

                entity.HasIndex(e => e.Senha)
                    .HasName("UQ__Usuarios__7ABB9731556BDC93")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
