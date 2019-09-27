using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using HelpLight.Data.Contexts;

namespace HelpLight.Data.Factories
{
    public class HelpLightDbContextFactory : IDesignTimeDbContextFactory<HelpLightDbContext>
    {
        public HelpLightDbContext Create(DbContextFactoryOptions options)
        {
            return Create();
        }

        public HelpLightDbContext Create()
        {
            return Create(/*pass string here*/);
        }

        public HelpLightDbContext Create(string connectionString)
        {
            return Create(connectionString, true);
        }

        public HelpLightDbContext Create(string connectionString, bool ensureDatabaseCreated)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<HelpLightDbContext>();
            optionsBuilder.UseSqlServer(connectionString /*?? DefaultConnectionString*/);

            var HelpLightDbContext = new HelpLightDbContext(optionsBuilder.Options);

            if (ensureDatabaseCreated)
            {
                HelpLightDbContext.Database.EnsureCreated();

                // TODO: 
                // if we will implement allow register Organization only from hardcoded list,
                // this could be seeded here
            }

            return HelpLightDbContext;
        }

        public HelpLightDbContext CreateDbContext(string[] args)
        {
            throw new System.NotImplementedException();
        }
    }
}


