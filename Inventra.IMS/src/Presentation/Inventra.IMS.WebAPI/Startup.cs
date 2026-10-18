using Inventra.IMS.Application;
using Inventra.IMS.Infrastructure;
using Inventra.IMS.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Inventra.IMS.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        private readonly IConfiguration Configuration;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public void ConfigureServices(IServiceCollection serviceDescriptors)
        {
            var connectionString = Configuration
                .GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "The connection string named 'DefaultConnection' was not found in the configuration!");

            string webRootPath = WebHostEnvironment.WebRootPath
            ?? Path.Combine(WebHostEnvironment.ContentRootPath, "wwwroot");

            Directory.CreateDirectory(webRootPath);

            string uploadRootPath = Path.Combine(webRootPath, "uploads");

            Directory.CreateDirectory(uploadRootPath);

            serviceDescriptors.AddApplicationServices();
            serviceDescriptors.AddPersistenceServices(connectionString);
            serviceDescriptors.AddInfrastructureServices(uploadRootPath);

            serviceDescriptors.AddControllers();

            serviceDescriptors.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            serviceDescriptors.AddEndpointsApiExplorer();
            serviceDescriptors.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
