using System;
using System.Collections.Generic;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data;

public partial class SistemaTicketContext : DbContext
{
    public SistemaTicketContext()
    {
    }

    public SistemaTicketContext(DbContextOptions<SistemaTicketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignadoUsuario> AsignadoUsuarios { get; set; }

    public virtual DbSet<EstadoTicket> EstadoTickets { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Respuesta> Respuesta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignadoUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Asignado__3214EC078B92E974");

            entity.ToTable("AsignadoUsuario");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdEstado).HasColumnName("Id_Estado");
            entity.Property(e => e.IdTicket).HasColumnName("Id_ticket");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.AsignadoUsuarios)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Estado_Asignado");

            entity.HasOne(d => d.IdTicketNavigation).WithMany(p => p.AsignadoUsuarios)
                .HasForeignKey(d => d.IdTicket)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Ticket_Asignado");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AsignadoUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Usuario_Asignado");
        });

        modelBuilder.Entity<EstadoTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstadoTi__3214EC07C43E83F4");

            entity.ToTable("EstadoTicket");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets__3214EC071B912F43");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Prioridad)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07F79F1B9B");

            entity.ToTable("Usuario");

            entity.Property(e => e.Cedula)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
