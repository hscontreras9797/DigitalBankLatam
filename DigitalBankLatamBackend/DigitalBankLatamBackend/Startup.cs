using Digital.Bank.Latam.Api.Abstractions;
using Digital.Bank.Latam.Api.EntityFramework;
using Digital.Bank.Latam.Api.EntityFramework.Repositories;
using Digital.Bank.Latam.Api.Logic;
using Digital.Bank.Latam.Api.Logic.Auth;
using Digital.Bank.Latam.Api.Logic.Usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBankLatamBackend
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
            var key = "Blue2023*@";
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers()
                .AddJsonOptions(options => { 
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.WriteIndented = true;
                });
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                       ValidateAudience = false,
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = false
                   };
               });
            services.AddAuthorization();
            
            // Context DB
            var connectionString = this.Configuration.GetConnectionString("DefaultConnectionString");

            var migration = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            //services.AddDbContext<Digital_Bank_LatamContext>(context => context.UseMemoryCache(DigitalBankLatamBackend));
            services.AddDbContext<Digital_Bank_LatamContext>(options =>
            {
               
                options.UseSqlServer(connectionString, sql =>
                {
                    sql.MigrationsAssembly(migration);
                });
            });

            // Swagger
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Usuarios {groupName}",
                    Version = groupName,
                    Description = "Digital Bank Latam API",
                    Contact = new OpenApiContact
                    {
                        Name = "Digital Bank Latam",
                        Email = string.Empty,
                        Url = new Uri("https://localhost:44346/"),
                    }
                });
            });

            // Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Repositories
            services.AddTransient<IUsuariosRepository, UsuariosRepository>();

            // Logic
            services.AddTransient<IUsuariosLogic, UsuariosLogic>();
            services.AddSingleton<IJwtAuthenticationService>(new JwtAuthenticationService(key));

            // Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            // Add Controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Digital Bank Latam Api V1");
            });

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
