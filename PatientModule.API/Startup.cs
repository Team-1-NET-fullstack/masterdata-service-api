using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using PatientModule.API.Models;
using PatientModule.API.PatientModule.API.BAL;
using PatientModule.API.PatientModule.API.BAL.PatientModule.API.BAL.Services;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Implementations;
using PatientModule.API.PatientModule.API.DAL.PatientModule.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientModule.API
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
            services.AddCors();
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PatientModule.API", Version = "v1" });
            });

            services.AddDbContext<CTGeneralHospitalContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:dbconn"]));
            string dbconn = Configuration.GetSection("ConnectionString").GetSection("dbConn").Value;
            services.AddScoped<PatientService>();
            services.AddScoped<PatientVisitService>();
            services.AddScoped<PatientVitalService>();
            services.AddScoped<AllergyService>();
            //services.AddScoped<AllergyMasterService>();


            services.AddScoped<IPatientRepository<Patient>, PatientRepository>();
            services.AddScoped<IPatientVisitRepository<PatientVisit>, PatientVisitRepository>();
            services.AddScoped<IPatientVitalRepository<PatientVital>, PatientVitalRepository>();
            services.AddScoped<IAllergyRepository<Allergy>, AllergyRepository>();
            //services.AddScoped<IAllergyMasterRepository<AllergyMaster>, AllergyMasterRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientModule.API v1"));
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());



            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
