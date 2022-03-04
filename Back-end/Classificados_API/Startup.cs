using Classificados_API.Controllers;
using Classificados_API.Interfaces;
using Classificados_API.Repositores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Classificados_API
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
            .AddControllers();
                

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                builder =>
                                {
                                    builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Classificados_API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Classificados-chave-autenticacao")),
                        ClockSkew = TimeSpan.FromMinutes(30),
                        ValidIssuer = "Classificados.webAPI",
                        ValidAudience = "Classificados.webAPI"
                    };
                });

            services.AddTransient<ITipoClassificados, TipoClassificadosRepository>();
            services.AddTransient<INicho, NichoRepository>();
            services.AddTransient<ICategorias, CategoriasRepository>();
            services.AddTransient<IClassificado, ClassificadoRepository>();
            services.AddTransient<IUsuario, UsuarioRepository>();
            services.AddTransient<ISituacao, SituacaoRepository>();
            services.AddTransient<IOferta, OfertaRepository>();


        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Classificados_API");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors("CorsPolicy");

            

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
