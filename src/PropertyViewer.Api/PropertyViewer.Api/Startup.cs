using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PropertyViewer.Domain;
using PropertyViewer.Infrastructure.PersistenceModel;
using PropertyViewer.Infrastructure.Repositories;

namespace PropertyViewer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddControllers().Services
                .AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins(Configuration["FrontEndUrl"]).AllowAnyHeader()))
                .AddDbContextPool<PropertyViewerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PropertyViewer")))
                .AddScoped<IPropertyRepository, PropertyRepository>()
        ;

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PropertyViewerContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            if (env.IsDevelopment())
            {
                context.Database.Migrate();
            }
        }
    }
}