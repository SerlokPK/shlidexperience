using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using shlidexperience.helpers;
using System.Collections.Generic;
using WebApi.Helpers;

namespace shlidexperience
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOptions()
                    .AddHttpClient()
                    .Configure<AppSettings>(Configuration.GetSection("AppSettings"))
                    .RegisterAppServices();

            var config = Configuration.GetSection("AppSettings");
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Shlidexpirience", Version = "v1" });
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                      },
                      new List<string>()
                    }
                });
            });

            var clientUrl = config.GetValue<string>("ClientUrl");
            services.RegisterAppCors(clientUrl);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint(url: "/swagger/v1/swagger.json", "Shlidexpirience");
            });
            // TODO setup logger
            app.UseHttpsRedirection()
               .UseCors(RegisterAppCorsHelper.AppCorsPolicyName)
               .UseRouting()
               .UseAuthorization()
               .UseMiddleware<JwtMiddleware>()
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapControllers();
               });
        }
    }
}
