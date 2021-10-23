using APIProject.Helper;
using APIProject.Middleware;
using ProjectDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using ServiceProject;
using System.Net;
using DataRepository;
using Microsoft.AspNetCore.Http.Features;

namespace APIProject
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
            services.AddTokenAuthentication(Configuration);
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            ResolveDependency(services);
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddSwaggerDocument();
            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
                #region Logexception
                app.UseExceptionHandler(appError =>
                {
                    appError.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature != null)
                        {
                            Log.Error($"Something went wrong: {contextFeature.Error}");

                            await context.Response.WriteAsync("Error Occurde");
                        }
                    });
                });
                #endregion

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            app.UseAuthentication();
        }

        private void ResolveDependency(IServiceCollection services)
        {
            //service dependency
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IOverallProjectStatusService, OverallProjectStatusService>();
            services.AddScoped<IProjectMilestoneService, ProjectMilestoneService>();
            services.AddScoped<IProjectUpdateService, ProjectUpdateService>();
            services.AddScoped<IRiskService, RiskService>();
            services.AddScoped<ITeamCompositionService, TeamCompositionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWorkAccomplishedService, WorkAccomplishedService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IClientService, ClientService>();


            //repository dependency
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IOverallProjectStatusRepository, OverallProjectStatusRepository>();
            services.AddScoped<IProjectMilestoneRepository, ProjectMilestoneRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectUpdateRepository, ProjectUpdateRepository>();
            services.AddScoped<IRiskRepository, RiskRepository>();
            services.AddScoped<ITeamCompositionRepository, TeamCompositionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkAccomplishedRepository, WorkAccomplishedRepository>();
        }
    }
}
