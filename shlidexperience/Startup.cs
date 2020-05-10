using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shlidexperience.helpers;

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

            var clientUrl = Configuration.GetSection("AppSettings").GetValue<string>("ClientUrl");
            services.RegisterAppCors(clientUrl);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // TODO setup logger
            app.UseHttpsRedirection()
               .UseCors(RegisterAppCorsHelper.AppCorsPolicyName)
               .UseRouting()
               .UseAuthorization()
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapControllers();
               });
        }
    }
}
