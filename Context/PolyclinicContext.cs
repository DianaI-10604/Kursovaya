using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using КурсоваяРабота.Models;

namespace КурсоваяРабота.Context;

public partial class PolyclinicContext : DbContext
{
    public PolyclinicContext()
    {
    }

    public PolyclinicContext(DbContextOptions<PolyclinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Medicalrecord> Medicalrecords { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Polyclinic;Username=postgres;password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("appointments_pkey");

            entity.ToTable("appointments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Appointmenttime).HasColumnName("appointmenttime");
            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Doctorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointments_doctorid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointments_userid_fkey");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doctors_pkey");

            entity.ToTable("doctors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Availabletimeafter).HasColumnName("availabletimeafter");
            entity.Property(e => e.Availabletimebefore).HasColumnName("availabletimebefore");
            entity.Property(e => e.DoctorDescription)
                .HasColumnType("character varying")
                .HasColumnName("doctor_description");
            entity.Property(e => e.Doctorname)
                .HasMaxLength(100)
                .HasColumnName("doctorname");
            entity.Property(e => e.Specialty)
                .HasMaxLength(100)
                .HasColumnName("specialty");
        });

        modelBuilder.Entity<Medicalrecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("medicalrecords_pkey");

            entity.ToTable("medicalrecords");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Appointmentid).HasColumnName("appointmentid");
            entity.Property(e => e.Diagnosis)
                .HasMaxLength(500)
                .HasColumnName("diagnosis");
            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Medicalrecords)
                .HasForeignKey(d => d.Appointmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicalrecords_appointmentid_fkey");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Medicalrecords)
                .HasForeignKey(d => d.Doctorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicalrecords_doctorid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Medicalrecords)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicalrecords_userid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dateofbirth).HasColumnName("dateofbirth");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Password).HasColumnType("character varying");
            //entity.Property(e => e.Passwordhash)
            //    .HasMaxLength(100)
            //    .HasColumnName("passwordhash");
            entity.Property(e => e.Patronymicname)
                .HasMaxLength(40)
                .HasColumnName("patronymicname");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Snils)
                .HasMaxLength(20)
                .HasColumnName("snils");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("username");
            entity.Property(e => e.Usersurname)
                .HasMaxLength(40)
                .HasColumnName("usersurname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
