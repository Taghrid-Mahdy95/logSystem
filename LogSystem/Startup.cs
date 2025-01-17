using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SD.LLBLGen.Pro.DQE.PostgreSql;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Npgsql;
using System.Diagnostics;

namespace LogSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;   
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            Conf.LLBLGen(Configuration);
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddRazorPages()
                .AddRazorPagesOptions(config =>
                {
                    config.Conventions.AuthorizeFolder("/Logs");
                    config.Conventions.AuthorizeFolder("/Projects");
                    config.Conventions.AllowAnonymousToPage("/Index");
                    config.Conventions.AllowAnonymousToPage("/Account/Login");
                });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.LoginPath = "/Account/Login");
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
    public static class Conf
    {
        public static void LLBLGen(IConfiguration config)
        {
            RuntimeConfiguration.AddConnectionString("ConnectionString.PostgreSql (Npgsql)", config.GetConnectionString("ConnectionString.PostgreSql (Npgsql)"));
            RuntimeConfiguration.ConfigureDQE<PostgreSqlDQEConfiguration>(c =>
            {
                c.AddDbProviderFactory(typeof(NpgsqlFactory));
            #if DEBUG
                c.SetTraceLevel(TraceLevel.Verbose);
            #endif
            });
        }
    }

}
