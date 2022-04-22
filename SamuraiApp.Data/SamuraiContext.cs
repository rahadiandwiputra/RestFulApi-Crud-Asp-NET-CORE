using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {

        /*public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options)
        {

        }*/
        /*public SamuraiContext()
        {

        }*/
        public SamuraiContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<SamuraiBattleStat> SamuraiBattleStats { get; set; }//secara default ini no tracking karena tidak punya key
        public DbSet<Sword> Swords { get; set; }
        public DbSet<Element> Elements { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SamuraiDB")//untuk menyambungkan ke database
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name,//untuk menampilkan logging
                DbLoggerCategory.Database.Transaction.Name},
                Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();
            //EnableSensitiveDataLogging() digunakan untuk menampilkan log sensitiv
            //if (!optionsBuilder.IsConfigured)
            //{
            // optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SamuraiDb");
            //}

        }*/

        //implementasi ini diperlukan jika dibutuhkan payloadnya data
        //(tambahan data/field contoh disini adanya tambahan DateTime di table BattleSamurai)
        //penerapan relasi many-to-many menggunakan fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>().HasMany(s => s.Battles)
                .WithMany(b => b.Samurais)
                .UsingEntity<BattleSamurai>(
                    bs => bs.HasOne<Battle>().WithMany(),
                    bs => bs.HasOne<Samurai>().WithMany())
                .Property(bs => bs.DateJoined)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Horse>().ToTable("Horses");
            modelBuilder.Entity<SamuraiBattleStat>().HasNoKey().ToView("SamuraiBattleStats");//secara default ini no tracking karena tidak punya key
        }
    }
}
