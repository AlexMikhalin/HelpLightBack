using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpLight.Data.Factories;
using HelpLight.Repository;
using HelpLight.Repository.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace HelpLight.Web
{
    public class Startup
    {
        private string connectionString;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            connectionString = Configuration.GetConnectionString("DatabaseConnection");

            serviceCollection.AddTransient(_ => new HelpLightDbContextFactory().Create(connectionString));

            serviceCollection.AddTransient<IUserRepository, UserRepository>();


            serviceCollection.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "My First ASP.NET Core Web API",
                    TermsOfService = "None"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
