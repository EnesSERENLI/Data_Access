using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entity;
using System.Data.Entity;

namespace DataAccess.Context
{
    public class MovieTheatherContext:DbContext
    {
        public MovieTheatherContext()
        {
            Database.Connection.ConnectionString = "server=DESKTOP-JOE5KI8\\SQLEXPRESS02;Database=CodeFirstMovieDB;Trusted_Connection=True;";
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MoviesAndCategories> MoviesAndCategories { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Saloon> Saloons { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Theather> Theathers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent Api => veri tabanı oluştururken kuralları(özelleştirme mesela=>nvarchar(max) olmasın) tanımlama
            //Data annotation => class içerisinde kuralları tanımlama
            modelBuilder.Entity<MoviesAndCategories>().HasKey(x => new //Ara tablonun primary key'lerini verdik..
            {
                x.CategoryId,
                x.MovieId
            });
            //Movies
            modelBuilder.Entity<Movie>().Property(x=>x.MovieName)
                .HasMaxLength(250) 
                .IsRequired(); 

            //Categories
            modelBuilder.Entity<Category>().Property(x=>x.CategoryName)
                .HasMaxLength(250)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
