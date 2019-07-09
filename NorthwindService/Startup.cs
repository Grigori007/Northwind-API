using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthwindContextLib;
using NorthwindService.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace NorthwindService
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
            services.AddDbContext<NorthwindDbContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true;"));
            services.AddScoped<IRepoCustomer, RepoCustomer>();
            // Registering generic service
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() {Title = "Northwind API", Version = "v1"});
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind API v1");
            });
        }
    }
}
