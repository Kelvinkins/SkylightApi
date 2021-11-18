using Camguard.Data.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Rewrite;
using Api.Authentication;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Api.Authentication.DataContext;
using Microsoft.AspNet.Identity.EntityFramework;
using Api.Authentication.Model;
using Api.Authentication.DAL;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Skylight.Data;
using Skylight.DAL;
using Skylight.Data.Models;
using Microsoft.Extensions.Options;
using Api.Service;

namespace Api
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
            services.Configure<HmoDatabaseSettings>(
            Configuration.GetSection(nameof(HmoDatabaseSettings)));

            services.AddSingleton<IHmoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<HmoDatabaseSettings>>().Value);
            services.AddSingleton<EmployeeService>();


            string connectionString = Configuration.GetConnectionString("CamguardPassportConnectionString");
                //@"Data Source=LAURINX-02\LAURINXPRESS;Initial Catalog=CamguardIdentity;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(connectionString)).AddScoped<AuthUnitOfWork>(); ;
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<IdentityContext>();

            services.AddControllers();
            services.AddDbContext<SkyDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlServerOptions => sqlServerOptions.CommandTimeout(60*20))).AddScoped<UnitOfWork>();

           
                    services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Skylight Api",
                    Description = "Skylight Api",
                    //TermsOfService = new Uri("#"),
                    Contact = new OpenApiContact
                    {
                        Name = "Skylight Api",
                        Email = string.Empty,
                        //Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Unauthorized use is prohibited",
                        //Url = new Uri("https://example.com/license"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
          
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


                app.UseHttpsRedirection();

                app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
                app.UseRouting();

                app.UseAuthentication();
                app.UseAuthorization();

                //app.UseIdentityServer();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();

                });
                //redirect to swagger documentation by default only on test and not on production environment
                var environment = Configuration.GetValue<string>("AppSettings:environment");
                //if (environment == "Dev")
                //{
                //Set-up Swagger endpoint
               
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skylight Api Documentation");

                });

                //app.UseRewriter(new RewriteOptions().AddRedirect("^$", "api-docs"));
                //}



            }
        }
    }
}
