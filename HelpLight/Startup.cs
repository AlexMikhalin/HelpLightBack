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
using AutoMapper;
using HelpLight.Repository.Convertors;

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
            Mapper.Initialize(m =>
            {
                m.AddProfile<MapperProfile>();
            });

            connectionString = Configuration.GetConnectionString("DatabaseConnection");

            serviceCollection.AddTransient(_ => new HelpLightDbContextFactory().Create(connectionString));

            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<IVolunteerReporitory, VolunteerRepository>();
            serviceCollection.AddTransient<IOrganizationRepository, OrganizationRepository>();
            serviceCollection.AddTransient<IApplicationRepository, ApplicationRepository>();
            serviceCollection.AddTransient<IBanRepository, BanRepository>();
            serviceCollection.AddTransient<IEventRepository, EventRepository>();
            serviceCollection.AddTransient<IKarmaRepository, KarmaRepository>();
            serviceCollection.AddTransient<IWallRepository, WallRepository>();
            serviceCollection.AddTransient<ICommentRepository, CommentRepository>();
            serviceCollection.AddTransient<ICardRepository, CarRepository>();
            serviceCollection.AddTransient<IReviewOfVolunteerRepository, ReviewOfVolunteerRepository>();

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

            serviceCollection.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
