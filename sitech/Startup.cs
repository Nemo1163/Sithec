using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sitech.Data.Context;
using sitech.DependecyContainer;
using sitech.DependecyContainer.Configure;
using sitech.Swagger;
using System.Collections.Generic;

namespace sitech
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddOpenApiDocument();
            services.AddDbContext<DBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DB")));
            DCFactory.CrateContainer<DC>(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseHttpsRedirection();
            app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi(settings =>
            {
                settings.DocumentName = ApiConfiguration.EndpointDescription;
                settings.PostProcess = (document, request) =>
                {
                    document.Schemes = new List<NSwag.OpenApiSchema> { NSwag.OpenApiSchema.Http, NSwag.OpenApiSchema.Https };
                    document.Swagger = "V1.0";
                    document.Produces = new List<string>
                    {
                        "application/json"
                    };
                    document.Info = new NSwag.OpenApiInfo
                    {
                        Title = ApiConfiguration.EndpointDescription + " - " + Configuration["Environment"],
                        Version = GetType().Assembly.GetName().Version.ToString(),
                        Description = ApiConfiguration.EndpointDescription,
                        Contact = new NSwag.OpenApiContact() { Name = ApiConfiguration.ContactName, Url = ApiConfiguration.ContactUrl },
                    };
                };

            });

            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
