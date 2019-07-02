using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Estagio.OpenSpaceAdmin.Models;
using Estagio.OpenSpaceAdmin.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Estagio.OpenSpaceAdmin
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            MapperConfiguration mapperConfiguration = new MapperConfiguration(
                cfg => { cfg.AddProfile(new AutoMapperProfile());
                }
            );
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddDbContext<OPENSPACEContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes => {
                routes.MapRoute("default", "api/{controller}/{action}/{id?}");
            });
        }
    }
}
