using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using P10.Server.DB;
using System.Linq;

namespace P10.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /* CORS */
            services.AddCors(Options =>
            {
                Options.AddPolicy("CorsPolicy",builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            /* CORS */
            services.AddControllersWithViews();
            services.AddRazorPages();
            var sqlConnectionString = "Host=ec2-3-224-7-166.compute-1.amazonaws.com;Port=5432;Database=da3pj65embas27;Username=jviuyrzubokgal;Password=4f80d80614dc58e90becf98650cb92634a351410544910c567c9a5d8249a7418;sslmode=Prefer;Trust Server Certificate=true;";
            services.AddDbContext<KalaDBContext>(options => options.UseNpgsql(sqlConnectionString));
            services.AddDbContext<UserDBContext>(options => options.UseNpgsql(sqlConnectionString));

            services.AddScoped<kalaProvider>();
            services.AddScoped<UserProvider>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
