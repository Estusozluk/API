using EstuSozluk.API.Repositories;
using EstuSozluk.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Serilog;

namespace EstuSozluk.API
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
            services.AddControllers();


            services.AddCors(options =>
            {
                options.AddPolicy(name: "Cors",
                    policy =>
                    {
                        policy
                            .WithOrigins("https://docs.solarproject.click", "https://www.solarproject.click")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(2, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });

            services.AddApiVersioning(setup =>
                setup.ApiVersionReader = new UrlSegmentApiVersionReader());

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["ConnectionStrings:Default"]));
            services.AddDbContext<EstuSozlukDbContext>(options =>
            {
                ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder
                    .AddConsole((options) => { })
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name
                 && level == LogLevel.Information);
                });
                options.UseMySQL(Configuration["ConnectionStrings:Default"]);
                options.UseLoggerFactory(_loggerFactory);
            });
            services.AddTransient<IEntryService, EntryService>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("Cors");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSerilogRequestLogging(options =>
            {
                //// Customize the message template
                //options.MessageTemplate = "Handled {RequestPath}";

                //// Emit debug-level events instead of the defaults
                //options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;

                //// Attach additional properties to the request completion event
                //options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                //{
                //    diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                //    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                //};
            });


            app.UseSwagger();
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.yaml", "V1");
            //    options.SwaggerEndpoint("/swagger/v2/swagger.yaml", "V2");
            //});


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
