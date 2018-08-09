using System;
using Frontend1.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frontend1
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
            services.AddMvc();
            // "http://localhost:64488/api/Books/"

            var url = Configuration["Bookservice:url"];
            if (string.IsNullOrWhiteSpace(url))
            {
                Console.WriteLine("Service url is null");
                url = Environment.GetEnvironmentVariable("Bookservice__url");
                if (string.IsNullOrWhiteSpace(url))
                {
                    Console.WriteLine("Service url is still null");
                    url = "http://bookservice/api/Books/";
                }
            }

            services.AddSingleton<IBookService>(new HttpRestBooksService(url));
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
