using AutoMapper;
using Company.Infra.Context;
using Company.Infra.DependencyInjection;
using Company.Infra.Repository;
using Company.Infra.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Skeleton.API
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
            // -- MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // -- Domain
            services.AddDomain(new List<BindingMap>{
                new BindingMap(typeof(IService), "Skeleton.Domain", "Skeleton.Impl.Services", ServiceLifetime.Singleton),
                new BindingMap(typeof(IRepository), "Skeleton.Domain", "Skeleton.Impl.Repositories", ServiceLifetime.Singleton)
            });

            // -- AutoMapper
            Mapper.Initialize(cfg => { });

            /*
             *  .----------------. 
             * | .--------------. |
             * | |      _       | |
             * | |     | |      | |
             * | |     | |      | |
             * | |     | |      | | Favor deixar o enxerto abaixo sempre
             * | |     |_|      | |  na última linha
             * | |     (_)      | |
             * | |              | |
             * | '--------------' |
             *  '----------------' 
             */
            ApplicationContext.SetProvider(services);
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
        }
    }
}
