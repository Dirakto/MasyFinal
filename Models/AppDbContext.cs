using Microsoft.EntityFrameworkCore;
using System;
using VSCode.Models;
using VSCode.Models.osiagniecie;
using VSCode.Models.bohater;
using VSCode.Models.rozgrywka;
using VSCode.Models.sezon;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace VSCode.Models
{
    public class AppDbContext : DbContext
    {

        public static AppDbContext Context { get; } = new AppDbContext();

        public AppDbContext() : base(){}
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

        public DbSet<Gracz> Gracze { get; set; }
        public DbSet<OsiagniecieZaUmiejetnosc> OsiagnieciaZaUmiejetnosc { get; set; }
        public DbSet<OsiagniecieGracza> OsiagnieciaGracza { get; set; }
        public DbSet<Ranking> Rankingi { get; set; }
        public DbSet<Sezon> Sezony { get; set; }


        public DbSet<RozgrywkaGracza> RozgrywkiGraczy { get; set; }
        public DbSet<StatystykiBohaterem> StatystykiBohaterami { get; set; }
        public DbSet<Bohater> Bohaterowie { get; set; }
        public DbSet<Umiejetnosc> Umiejetnosci { get; set; }
        public DbSet<Rozgrywka> Rozgrywki { get; set; }
        public DbSet<Mapa> Mapy { get; set; }
        public DbSet<TypMapy> TypyMap { get; set; }

        // public DbSet<BohaterOfensywny> BohaterowieOfensywni { get; set; }
        // public DbSet<BohaterDefensywny> BohaterowieDefensywni { get; set; }
        // public DbSet<BohaterPomocniczy> BohaterowiePomocniczy { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=finalmasy;user=oskar;password=oskar");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Osiagniecie>().ToTable("Osiagniecia");

            modelBuilder.Entity<Bohater>( b => {
                b.Property(p => p.Podklasy)
                    .HasConversion(
                        d => JsonConvert.SerializeObject(d, Formatting.None),
                        s => JsonConvert.DeserializeObject<Dictionary<string, Object>>(s)
                    ).IsRequired();
            });
            modelBuilder.Entity<Bohater>()
                .HasMany(u => u.Umiejetnosci)
                .WithOne(o => o.Bohater)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}