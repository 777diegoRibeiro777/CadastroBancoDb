using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CadastroBancoDb.Models
{
    public partial class CadastroBancoDbContext : IdentityDbContext<IdentityUser>
    {
        public CadastroBancoDbContext()
        {
        }

        public CadastroBancoDbContext(DbContextOptions<CadastroBancoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agencium> Agencia { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Contum> Conta { get; set; } = null!;
        public virtual DbSet<Emprestimo> Emprestimos { get; set; } = null!;
        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public virtual DbSet<Transacao> Transacaos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Agencium>(entity =>
            {
                entity.HasKey(e => e.Idagencia)
                    .HasName("PK__Agencia__ECA89708C3F76E03");

                entity.Property(e => e.Idagencia)
                    .ValueGeneratedNever()
                    .HasColumnName("IDAgencia");

                entity.Property(e => e.Endereco).HasMaxLength(255);

                entity.Property(e => e.GerenteResponsavel).HasMaxLength(100);

                entity.Property(e => e.NumeroTelefone).HasMaxLength(20);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idconta)
                    .HasName("PK__Cliente__FBA4DC180B643728");

                entity.ToTable("Cliente");

                entity.Property(e => e.Idconta)
                    .ValueGeneratedNever()
                    .HasColumnName("IDConta");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Endereco).HasMaxLength(255);

                entity.Property(e => e.Nome).HasMaxLength(100);

                entity.Property(e => e.NumeroTelefone).HasMaxLength(20);
            });

            modelBuilder.Entity<Contum>(entity =>
            {
                entity.HasKey(e => e.Idconta)
                    .HasName("PK__Conta__FBA4DC186984DEB5");

                entity.Property(e => e.Idconta)
                    .ValueGeneratedNever()
                    .HasColumnName("IDConta");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoConta).HasMaxLength(50);

                entity.HasOne(d => d.ClienteTitularNavigation)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.ClienteTitular)
                    .HasConstraintName("FK__Conta__ClienteTi__4BAC3F29");
            });

            modelBuilder.Entity<Emprestimo>(entity =>
            {
                entity.HasKey(e => e.Idemprestimo)
                    .HasName("PK__Empresti__4DAA6446F7FD9207");

                entity.ToTable("Emprestimo");

                entity.Property(e => e.Idemprestimo)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEmprestimo");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.TaxaJuros).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ValorEmprestimo).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ClienteBeneficiarioNavigation)
                    .WithMany(p => p.Emprestimos)
                    .HasForeignKey(d => d.ClienteBeneficiario)
                    .HasConstraintName("FK__Emprestim__Clien__52593CB8");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.Idfuncionario)
                    .HasName("PK__Funciona__3E1A7BE758D8DED2");

                entity.ToTable("Funcionario");

                entity.Property(e => e.Idfuncionario)
                    .ValueGeneratedNever()
                    .HasColumnName("IDFuncionario");

                entity.Property(e => e.Cargo).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Nome).HasMaxLength(100);

                entity.Property(e => e.NumeroTelefone).HasMaxLength(20);
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(e => e.Idtransacao)
                    .HasName("PK__Transaca__07EB7E5B2BECF669");

                entity.ToTable("Transacao");

                entity.Property(e => e.Idtransacao)
                    .ValueGeneratedNever()
                    .HasColumnName("IDTransacao");

                entity.Property(e => e.DataHoraTransacao).HasColumnType("datetime");

                entity.Property(e => e.TipoTransacao).HasMaxLength(50);

                entity.Property(e => e.ValorTransacao).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ContaEnvolvidaNavigation)
                    .WithMany(p => p.Transacaos)
                    .HasForeignKey(d => d.ContaEnvolvida)
                    .HasConstraintName("FK__Transacao__Conta__5535A963");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
