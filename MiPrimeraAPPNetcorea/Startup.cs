using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MiPrimeraAPPNetcorea.Infraestructure;
using MiPrimeraAPPNetcorea.Repository;
using MiPrimeraAPPNetcorea.Repository.IRepository;
using AutoMapper;
using MiPrimeraAPPNetcorea.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;
using System.IO;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace MiPrimeraAPPNetcorea
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddDbContext<CatalogoDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(CategoriaMapper));
            services.AddAutoMapper(typeof(UsuarioMapper));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:TokenKey").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            //Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("CatalogosCategoriasAPI", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Catalogos Generales API",
                    Description = "Contiene los catalogos genericos de aplicaciones",
                    Version = "1.0",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "soluciones@axsistec.com",
                        Name = "Soporte tecnico a desarrollos",
                        Url = new Uri("https://axsistecnologia.com")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "BSD",
                        Url = new Uri("https://bsd.axsistec.com")
                    }
                });



                options.SwaggerDoc("APIUsuariosCatalogo", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Usuarios API",
                    Description = "Contiene los catalogos genericos de aplicaciones",
                    Version = "1.0",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "soluciones@axsistec.com",
                        Name = "Soporte tecnico a desarrollos",
                        Url = new Uri("https://axsistecnologia.com")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "BSD",
                        Url = new Uri("https://bsd.axsistec.com")
                    }
                });


                var XMLComentarios = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var APIRutaComentarios = Path.Combine(AppContext.BaseDirectory, XMLComentarios);
                options.IncludeXmlComments(APIRutaComentarios);

                options.AddSecurityDefinition("Bearer",
                   new OpenApiSecurityScheme
                   {
                       Description = "JWT Authentication",
                       Type = SecuritySchemeType.Http,
                       Scheme = "bearer"
                   });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id= "Bearer",
                                Type= ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });

            });


            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //        builder =>
            //        {
            //            builder.WithOrigins("http://google.com",
            //                                "http://facebook.com");

            //        });
            //});

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/CatalogosCategoriasAPI/swagger.json", "API Catalogos");
                options.SwaggerEndpoint("swagger/APIUsuariosCatalogo/swagger.json", "API Usuario Catalgo");
                options.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseCors(MyAllowSpecificOrigins);
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        }
    }
}
