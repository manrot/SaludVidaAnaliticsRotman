﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SaludVidaAnaliticsRotman.Models;

public partial class DbsaludVidaContext : DbContext
{
    public DbsaludVidaContext()
    {
    }

    public DbsaludVidaContext(DbContextOptions<DbsaludVidaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Consultorio> Consultorios { get; set; }

    public virtual DbSet<EquipoMedico> EquipoMedicos { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<RelacionConsultorioEquiposMedico> RelacionConsultorioEquiposMedicos { get; set; }

    public virtual DbSet<RelacionConsultorioEspecialidade> RelacionConsultorioEspecialidades { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita);

            entity.Property(e => e.CostoConsulta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.IdConsultorioNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdConsultorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Citas_Consultorios");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdEspecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Citas_Especialidades");

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdHorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Citas_Horarios");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Citas_Medicos");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Citas_Pacientes");
        });

        modelBuilder.Entity<Consultorio>(entity =>
        {
            entity.HasKey(e => e.IdConsultorio);

            entity.Property(e => e.NombreConsultorio)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EquipoMedico>(entity =>
        {
            entity.HasKey(e => e.IdEquipo);

            entity.ToTable("EquipoMedico");

            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Activo')");
            entity.Property(e => e.NombreEquipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad);

            entity.Property(e => e.Descripcion).HasMaxLength(400);
            entity.Property(e => e.NombreEspecialidad)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario);
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico);

            entity.Property(e => e.Apellido1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Apellido2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Identificacion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreMedico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroLicenciaMedica)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdEspecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicos_Especialidades");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente);

            entity.Property(e => e.Apellido1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Apellido2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Identificacion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RelacionConsultorioEquiposMedico>(entity =>
        {
            entity.HasKey(e => e.IdRelacion);

            entity.ToTable("Relacion_Consultorio_EquiposMedicos");

            entity.Property(e => e.IdRelacion).HasColumnName("Id_Relacion");

            entity.HasOne(d => d.IdConsultorioNavigation).WithMany(p => p.RelacionConsultorioEquiposMedicos)
                .HasForeignKey(d => d.IdConsultorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Relacion_Consultorio_EquiposMedicos_Consultorios");

            entity.HasOne(d => d.IdEquipoMedicoNavigation).WithMany(p => p.RelacionConsultorioEquiposMedicos)
                .HasForeignKey(d => d.IdEquipoMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Relacion_Consultorio_EquiposMedicos_EquipoMedico");
        });

        modelBuilder.Entity<RelacionConsultorioEspecialidade>(entity =>
        {
            entity.HasKey(e => e.IdRelacion);

            entity.ToTable("Relacion_Consultorio_Especialidades");

            entity.HasOne(d => d.IdConsultorioNavigation).WithMany(p => p.RelacionConsultorioEspecialidades)
                .HasForeignKey(d => d.IdConsultorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Relacion_Consultorio_Especialidades_Consultorios");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.RelacionConsultorioEspecialidades)
                .HasForeignKey(d => d.IdEspecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Relacion_Consultorio_Especialidades_Especialidades");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
