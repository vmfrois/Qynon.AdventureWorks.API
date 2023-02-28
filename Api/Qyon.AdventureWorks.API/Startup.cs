using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Qynon.AdventureWorks.Infrastructure.Data;
using Qynon.AdventureWorks.Infrastructure.Data.EfCore;
using Qynon.AdventureWorks.Service;
using Qynon.AdventureWorks.Service.Handlers;
using Qynon.AdventureWorks.Services;

namespace Qynon.AdventureWorks.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //DAOs
            services.AddScoped<ICompetidorDao, CompetidorDao>();
            services.AddScoped<IPistaCorridaDao, PistaCorridaDao>();
            services.AddScoped<IHistoricoCorridaDao, HistoricoCorridaDao>();

            //Services
            services.AddScoped<IPistaCorridaService, PistaUtilizadasService>();
            services.AddScoped<ICompetidorService, CompetidorSemCorridaService>();
            services.AddScoped<IHistoricoCorridaService, DefaultHistoricoCorridaService>();
            services.AddScoped<ICompetidorService, DefaultCompetidorService>();
            services.AddScoped<IPistaCorridaService, DefaultPistaCorridaService>();


            //Banco de dados
            var connectionString = Configuration.GetConnectionString("QyonDB");
            services.AddDbContext<AppDbContext>(o =>
                    o.UseNpgsql(connectionString));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
