using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestTask.MVC.AutoMapper;
using TestTask.PostgreSQL;
using TestTask.PostgreSQL.Repository;
namespace TestTask.MVC
{
    public class Startup
    {
        private readonly IConfiguration _configurtaion;

        public Startup(IConfiguration configurtaion)
        {
            _configurtaion = configurtaion;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPFRRepository, PFRRepository>();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(_configurtaion.GetConnectionString("DataContext"));
            });

            services.AddAutoMapper(typeof(MVCAutoMapperProfile));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
