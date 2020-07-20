using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Test;
using GraphiQl;
using Lamar;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace backend
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
            //Injection for MediatR
            services.AddMediatR(typeof(Startup));
            
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Needed to add for graphiql to work
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        public void ConfigureContainer(ServiceRegistry services)
        {
            //this is where you do the dependency injection for lamar
           services.For<ITest>().Use(new Test.Test("Pie is good")).Singleton();
        
           services.Scan(s => {
               s.TheCallingAssembly();
               s.WithDefaultConventions();
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();
            
            //add graphql
            app.UseGraphiQl("/graphiql");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
