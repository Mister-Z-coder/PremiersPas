using AutoMapper;
using FrontendMVC.Mapper;
using FrontendMVC.Services;
using FrontendMVC.Services.Factories;
using FrontendMVC.Services.Implementations;
using FrontendMVC.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendMVC
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
            services.AddControllersWithViews();


            //recupération de l'url dans le fichier appsettings.json
            var apiBaseUrl = Configuration["ApiSettings:BaseUrl"];

            //Ajout AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // HttpClient global
            services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            });

            //Ajout IHHtpContextFactory
            services.AddScoped<IHttpClientFactoryService, HttpClientFactoryService>();

            //Ajout services génériques et spécifiques
            services.AddScoped(typeof(IApiService<>), typeof(BaseApiService<,>));
            services.AddScoped<IAnneeScolaireApiService, AnneeScolaireApiService>();
            services.AddScoped<IEcoleApiService, EcoleApiService>();
            services.AddScoped<IEleveApiService, EleveApiService>();
            services.AddScoped<IInscriptionApiService, InscriptionApiService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
