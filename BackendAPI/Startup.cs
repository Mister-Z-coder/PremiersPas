using AutoMapper;
using BackendAPI.Data;
using BackendAPI.Exceptions;
using BackendAPI.Mapper;
using BackendAPI.Repositories;
using BackendAPI.Repositories.Implementations;
using BackendAPI.Repositories.Interfaces;
using BackendAPI.Services;
using BackendAPI.Services.Implementations;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI
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
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")

            ));

            //Ajout AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            //Ajout repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEcoleRepository,EcoleRepository>();
            services.AddScoped<IEleveRepository,EleveRepository>();
            services.AddScoped<IAnneeScolaireRepository,AnneeScolaireRepository>();
            services.AddScoped<IInscriptionRepository,InscriptionRepository>();

            //Ajout services
            services.AddScoped(typeof(IService<>), typeof(BaseService<>));
            services.AddScoped<IEcoleService,EcoleService>();
            services.AddScoped<IEleveService,EleveService>();
            services.AddScoped<IAnneeScolaireService,AnneScolaireService>();
            services.AddScoped<IInscriptionService,InscrpitionService>();


            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;           // toutes les routes générées seront converties en minuscules
                options.LowercaseQueryStrings = true;   // optionnel : les query strings seront aussi en minuscules
            });
            services.AddHttpContextAccessor();

            //Service pour la gestion de l'uri
            services.AddSingleton<IUriService>(options =>
            {
                var accessor = options.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());//Construit la base URI (ex: https:///example.com). Host.ToUriComponent() encode proprement le host:port.
                return new UriService(uri);
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackendAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackendAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
