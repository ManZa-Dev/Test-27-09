using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_Biblioteca_Bella.Models;

public partial class BibliotecaBellaContext : DbContext
{
    public BibliotecaBellaContext()
    {
    }

    public BibliotecaBellaContext(DbContextOptions<BibliotecaBellaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Prestito> Prestitos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-10\\SQLEXPRESS;Database=Biblioteca_Bella;User Id=academy;Password=Academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libro__18C65F4B73E49205");

            entity.ToTable("Libro");

            entity.Property(e => e.LibroId).HasColumnName("libroID");
            entity.Property(e => e.AnnoPub).HasColumnName("anno_pub");
            entity.Property(e => e.IsDisp)
                .HasDefaultValue(true)
                .HasColumnName("isDisp");
            entity.Property(e => e.LibroCod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("libroCOD");
            entity.Property(e => e.Titolo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("titolo");
        });

        modelBuilder.Entity<Prestito>(entity =>
        {
            entity.HasKey(e => e.PrestitoId).HasName("PK__Prestito__7E579A753EFFCCE8");

            entity.ToTable("Prestito");

            entity.Property(e => e.PrestitoId).HasColumnName("prestitoID");
            entity.Property(e => e.FinPrest)
                .HasColumnType("datetime")
                .HasColumnName("fin_prest");
            entity.Property(e => e.IniPrest)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ini_prest");
            entity.Property(e => e.LibroRif).HasColumnName("libroRIF");
            entity.Property(e => e.PrestitoCod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("prestitoCOD");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.LibroRifNavigation).WithMany(p => p.Prestitos)
                .HasForeignKey(d => d.LibroRif)
                .HasConstraintName("FK__Prestito__libroR__4D94879B");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Prestitos)
                .HasForeignKey(d => d.UtenteRif)
                .HasConstraintName("FK__Prestito__utente__4CA06362");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C225371A4D0F3");

            entity.ToTable("Utente");

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.UtenteCod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("utenteCOD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
