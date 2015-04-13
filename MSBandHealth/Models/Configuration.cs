namespace MSBandHealth.Migrations
{
    using MSBandHealth.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MSBandHealth.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MSBandHealth.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Pulses.AddOrUpdate(p => p.Id,
                new Pulse { Id = 0, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(0), BPM = 68 },
                new Pulse { Id = 1, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(1), BPM = 67 },
                new Pulse { Id = 2, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(2), BPM = 68 },
                new Pulse { Id = 3, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(3), BPM = 69 },
                new Pulse { Id = 4, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(4), BPM = 70 }
            );

            context.ActivityLevels.AddOrUpdate(p => p.Id,
                new ActivityLevel { Id = 0, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(0), Level = "IDLE" },
                new ActivityLevel { Id = 1, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(1), Level = "WALKING" },
                new ActivityLevel { Id = 2, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(2), Level = "WALKING" },
                new ActivityLevel { Id = 3, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(3), Level = "WALKING" },
                new ActivityLevel { Id = 4, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(4), Level = "JOGGING" }
            );


            context.SkinTemperatures.AddOrUpdate(p => p.Id,
                new SkinTemperature { Id = 0, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(0), Temperature = 32.5 },
                new SkinTemperature { Id = 1, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(1), Temperature = 32.7 },
                new SkinTemperature { Id = 2, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(2), Temperature = 33.0 },
                new SkinTemperature { Id = 3, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(3), Temperature = 33.1 },
                new SkinTemperature { Id = 4, Name = "Rick Grimes", Time = DateTime.Now.AddMinutes(4), Temperature = 33.5 }
            );
        }
    }
}
