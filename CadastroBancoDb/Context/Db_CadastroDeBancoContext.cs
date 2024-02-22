using System;
using System.Collections.Generic;
using CadastroBancoDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CadastroBancoDb.Context
{
    public partial class Db_CadastroDeBancoContext : DbContext
    {
        public Db_CadastroDeBancoContext()
        {
        }

        public Db_CadastroDeBancoContext(DbContextOptions<Db_CadastroDeBancoContext> options)
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
            modelBuilder.Entity<Agencium>(entity =>
            {
                entity.HasKey(e => e.NumeroAgencia)
                    .HasName("PK__Agencia__CA5B9A1DE9F9B3F6");

                entity.Property(e => e.NumeroAgencia).ValueGeneratedNever();

                entity.Property(e => e.Endereco).HasMaxLength(255);

                entity.Property(e => e.GerenteResponsavel).HasMaxLength(100);

                entity.Property(e => e.NumeroTelefone).HasMaxLength(20);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.NumeroConta)
                    .HasName("PK__Cliente__C551C75D41BA008C");

                entity.ToTable("Cliente");

                entity.Property(e => e.NumeroConta).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Endereco).HasMaxLength(255);

                entity.Property(e => e.Nome).HasMaxLength(100);

                entity.Property(e => e.NumeroTelefone).HasMaxLength(20);
            });

            modelBuilder.Entity<Contum>(entity =>
            {
                entity.HasKey(e => e.NumeroConta)
                    .HasName("PK__Conta__C551C75D5B3F2973");

                entity.Property(e => e.NumeroConta).ValueGeneratedNever();

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoConta).HasMaxLength(50);

                entity.HasOne(d => d.ClienteTitularNavigation)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.ClienteTitular)
                    .HasConstraintName("FK__Conta__ClienteTi__398D8EEE");
            });

            modelBuilder.Entity<Emprestimo>(entity =>
            {
                entity.HasKey(e => e.Idemprestimo)
                    .HasName("PK__Empresti__4DAA6446DCF653B4");

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
                    .HasConstraintName("FK__Emprestim__Clien__403A8C7D");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.Idfuncionario)
                    .HasName("PK__Funciona__3E1A7BE7DB415507");

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
                    .HasName("PK__Transaca__07EB7E5B096001C6");

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
                    .HasConstraintName("FK__Transacao__Conta__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
