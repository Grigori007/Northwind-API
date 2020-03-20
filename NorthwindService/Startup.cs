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
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NorthwindDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Northwind")));
            services.AddScoped(typeof(IBaseRepository<Category>), typeof(CategoriesRepository));
            services.AddScoped(typeof(IBaseRepository<Customer>), typeof(CustomersRepository));
            services.AddScoped(typeof(IBaseRepository<Employee>), typeof(EmployeesRepository));
            services.AddScoped(typeof(IBaseRepository<Order>), typeof(OrdersRepository));
            services.AddScoped(typeof(IBaseRepository<OrderDetail>), typeof(OrderDetailsRepository));
            services.AddScoped(typeof(IBaseRepository<Product>), typeof(ProductsRepository));
            services.AddScoped(typeof(IBaseRepository<Shipper>), typeof(ShippersRepository));
            services.AddScoped(typeof(IBaseRepository<Supplier>), typeof(SuppliersRepository));
            // services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            // Disabling looping in order for eager loading to work properly
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "Northwind API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
