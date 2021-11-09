using MasterData.Service.Api.BAL.Services;
using MasterData.Service.Api.DAL;
using MasterData.Service.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins("http://localhost:59523", "http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod();
                });
            });
            services.AddDbContext<CTGeneralHospitalContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:dbConn"]));

            services.Configure<CTGeneralHospitalDatabaseSettings>(
                Configuration.GetSection(nameof(CTGeneralHospitalDatabaseSettings)));

            services.AddSingleton<ICTGeneralHospitalDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CTGeneralHospitalDatabaseSettings>>().Value);

            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", false)
                                .Build();
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            services.AddSingleton<AllergyMasterService>();
            services.AddSingleton<DiagnosisMasterService>();
            services.AddSingleton<MedicationMasterService>();
            services.AddSingleton<ProcedureMasterService>();
            services.AddControllers().AddNewtonsoftJson(options => options.UseMemberCasing());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MasterData.Service.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MasterData.Service.Api v1"));
            }
            app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());
            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
