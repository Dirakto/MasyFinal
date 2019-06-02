using Microsoft.EntityFrameworkCore;
using System;
using VSCode.Models;
using VSCode.Models.osiagniecie;
using VSCode.Models.bohater;
using VSCode.Models.rozgrywka;
using VSCode.Models.sezon;

namespace VSCode.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

        public DbSet<Gracz> Gracze { get; set; }
        public DbSet<OsiagniecieZaUmiejetnosc> OsiagnieciaZaUmiejetnosc { get; set; }
        public DbSet<OsiagniecieGracza> OsiagnieciaGracza { get; set; }
        public DbSet<Ranking> Rankingi { get; set; }
        public DbSet<Sezon> Sezony { get; set; }

        // public DbSet<Rozgrywka> Rozgrywki { get; set; }


        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        //     optionsBuilder.UseMySQL(Start);
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Osiagniecie>().ToTable("Osiagniecia");

        }

    }
}