using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAO.Models;

public partial class GestorBibliotecaPersonalContext : DbContext
{
    public GestorBibliotecaPersonalContext()
    {
    }

    public GestorBibliotecaPersonalContext(DbContextOptions<GestorBibliotecaPersonalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=gestorBibliotecaPersonal;Username=postgres;Password=Flash12311");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("libro_pkey");

            entity.ToTable("libros", "ges_alm");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('ges_alm.libro_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Autor).HasColumnName("autor");
            entity.Property(e => e.Isbn).HasColumnName("isbn");
            entity.Property(e => e.Titulo).HasColumnName("titulo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
