using App.Api.Configuration;
using App.Domain.Contracts.Repository;
using App.Domain.Contracts.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace App.Api
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
            services.AddMvc();
            
            services.AddDomain(new List<BindingMap>{
                new BindingMap(typeof(IService), new []{"App.Impl.Service"}, ServiceLifetime.Scoped),
                new BindingMap(typeof(IRepository), new[]{"App.Impl.Repository"}, ServiceLifetime.Scoped)
            });

            LogConfiguration.Configure();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
