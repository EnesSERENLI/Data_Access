namespace HamburgerDB.Migrations
{
    using HamburgerDB.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HamburgerDB.Context.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HamburgerDB.Context.ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            //If there is fake data that we will add to the database we have created, it can do this within the seed method.
            if (!context.Hamburgers.Any())
            {
                Hamburger h1 = new Hamburger();
                h1.Name = "Whooper";
                h1.Price = 25;
                
                Hamburger h2 = new Hamburger();
                h1.Name = "SteakHouse";
                h1.Price = 35;
                
                Hamburger h3 = new Hamburger();
                h1.Name = "ChickenBurger";
                h1.Price = 20;

                context.Hamburgers.Add(h1);
                context.Hamburgers.Add(h2);
                context.Hamburgers.Add(h3);
                context.SaveChanges();
            }

            if (!context.Extras.Any())
            {
                Extra e0 = new Extra();
                e0.Name = "None";
                e0.Price = 0;
                
                Extra e1 = new Extra();
                e1.Name = "Ketchup";
                e1.Price = 2;
                
                Extra e2 = new Extra();
                e2.Name = "Mayonnaise";
                e2.Price = 2;
                
                Extra e3 = new Extra();
                e3.Name = "G.Mayonnaise";
                e3.Price = 2;
                
                Extra e4 = new Extra();
                e4.Name = "Chaddar";
                e4.Price = 3;
                
                Extra e5 = new Extra();
                e5.Name = "Ranch";
                e5.Price = 3;

                context.Extras.Add(e0);
                context.Extras.Add(e1);
                context.Extras.Add(e2);
                context.Extras.Add(e3);
                context.Extras.Add(e4);
                context.Extras.Add(e5);
                context.SaveChanges();
            }

            if (!context.Dimensions.Any())
            {
                Dimension d1 = new Dimension();
                d1.Size = "Small";
                d1.Price = 0;
                
                Dimension d2 = new Dimension();
                d2.Size = "Middle";
                d2.Price = 3;
               
                Dimension d3 = new Dimension();
                d3.Size = "Large";
                d3.Price = 5;

                context.Dimensions.Add(d1);
                context.Dimensions.Add(d2);
                context.Dimensions.Add(d3);
                context.SaveChanges();
            }
        }
    }
}
