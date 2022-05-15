using HamburgerDB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerDB.Context
{
    public class ProjectContext : DbContext //To create the database we have to inherit from DbContext. To do this, we must have added the EntityFramework library to the project.
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "server=DESKTOP-JOE5KI8\\SQLEXPRESS02;database=HamburgerDB;Trusted_Connection=True;";
        }

        public DbSet<Hamburger> Hamburgers { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Detail> Order_Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
             With this crushable method, we can adjust many settings in the database.
            -Create many - to - many tables
            - Primary key setting
            -Determining data types
            -Allow or not to pass null
             */

            //There is no need for intermediate table in this database. But this way it can be created in the intermediate table.

            //modelBuilder.Entity<Hamburger>() 
            //    .HasMany(x => x.Orders)
            //    .WithMany(x => x.Hamburger)
            //    .Map(map =>
            //    {
            //        map.ToTable("HamburgerOrders");
            //        map.MapLeftKey("HamburgerId");
            //        map.MapRightKey("OrderId");
            //    });

            modelBuilder.Entity<Hamburger>().Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Hamburger>().Property(x => x.Price)
                .IsRequired();
            modelBuilder.Entity<Extra>().Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Extra>().Property(x => x.Price)
                .IsRequired();
            modelBuilder.Entity<Dimension>().Property(x => x.Size)
               .HasMaxLength(50)
               .IsRequired();
            modelBuilder.Entity<Dimension>().Property(x => x.Price)
                .IsRequired();
            modelBuilder.Entity<Order_Detail>().Property(x => x.ExtraId)
                .IsOptional();
        }
    }
}
