using Microsoft.EntityFrameworkCore;
using Qynon.AdventureWorks.Models;

namespace Qynon.AdventureWorks.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Competidor> Competidores { get; set; }

        public DbSet<PistaCorrida> PistasCorrida { get; set; }

        public DbSet<HistoricoCorrida> HistoricoCorrida { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competidor>(entity =>
            {
                entity.ToTable("competidores");
                
                entity.HasKey(e => e.Id).HasName("id"); ;
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Altura).IsRequired().HasColumnName("altura");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("nome");

                entity.Property(e => e.Peso).IsRequired().HasColumnName("peso");

                entity.Property(e => e.Sexo).IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("sexo");

                entity.Property(e => e.TemperaturaMediaCorpo).IsRequired()
                     .HasColumnName("temperaturamediacorpo");
            });

            modelBuilder.Entity<PistaCorrida>(entity =>
            {
                entity.ToTable("PistaCorrida");

                entity.HasKey(p => p.Id).HasName("id");
                entity.Property(p => p.Id).IsRequired().HasColumnName("id");

                entity.Property(p => p.Descricao).IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<HistoricoCorrida>(entity =>
            {
                entity.ToTable("HistoricoCorrida");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.CompetidorId).IsRequired();
                entity.Property(e => e.PistaCorridaId).IsRequired();
                entity.Property(e => e.DataCorrida).IsRequired();
                entity.Property(e => e.TempoGasto).IsRequired();

                entity.HasOne(h => h.Competidor)
                      .WithMany()
                      .HasForeignKey(h => h.CompetidorId);

                entity.HasOne(h => h.PistaCorrida)
                      .WithMany()
                      .HasForeignKey(h => h.PistaCorrida);


            });

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
