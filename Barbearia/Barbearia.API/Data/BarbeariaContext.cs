using System;
using System.Collections.Generic;
using Barbearia.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.API.Data;

public partial class BarbeariaContext : DbContext
{
    public BarbeariaContext()
    {
    }

    public BarbeariaContext(DbContextOptions<BarbeariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendamento> Agendamentos { get; set; }

    public virtual DbSet<Barbeiro> Barbeiros { get; set; }

    public virtual DbSet<Filial> Filiais { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__agendame__3214EC278841F34B");

            entity.ToTable("agendamentos");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BarbeiroId).HasColumnName("BARBEIRO_ID");
            entity.Property(e => e.DataAgendamento).HasColumnName("DATA_AGENDAMENTO");
            entity.Property(e => e.FilialId).HasColumnName("FILIAL_ID");
            entity.Property(e => e.HoraAgendamento).HasColumnName("HORA_AGENDAMENTO");
            entity.Property(e => e.Servico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SERVICO");
            entity.Property(e => e.UsuarioId).HasColumnName("USUARIO_ID");

            entity.HasOne(d => d.Barbeiro).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.BarbeiroId)
                .HasConstraintName("FK__agendamen__BARBE__3E52440B");

            entity.HasOne(d => d.Filial).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.FilialId)
                .HasConstraintName("FK__agendamen__FILIA__3F466844");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__agendamen__USUAR__3D5E1FD2");
        });

        modelBuilder.Entity<Barbeiro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BARBEIRO__3214EC2760324889");

            entity.ToTable("BARBEIROS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Especialidade)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ESPECIALIDADE");
            entity.Property(e => e.FilialId).HasColumnName("FILIAL_ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOME");

            entity.HasOne(d => d.Filial).WithMany(p => p.Barbeiros)
                .HasForeignKey(d => d.FilialId)
                .HasConstraintName("FK__BARBEIROS__FILIA__38996AB5");
        });

        modelBuilder.Entity<Filial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FILIAIS__3214EC278AC07065");

            entity.ToTable("FILIAIS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ENDERECO");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOME");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USUARIOS__3214EC27AF3F0972");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataCadastro).HasColumnName("DATA_CADASTRO");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOME");
            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SENHA");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
