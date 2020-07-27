using Leilao.Domain.Handlers;
using Leilao.Infra.Contexts;
using Leilao.Infra.Repositories;
using Leilao.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Leilao.Api
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
            services.AddControllers();
            //services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Database"));
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connectionLocalDb")));

            services.AddTransient<ILeilaoRepository, LeilaoRepository>();
            services.AddTransient<LeilaoHandler, LeilaoHandler>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<UserHandler, UserHandler>();

            services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Authority = "https://securetoken.google.com/leiloes-128aa";
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidIssuer = "https://securetoken.google.com/leiloes-128aa",
                       ValidateAudience = true,
                       ValidAudience = "leiloes-128aa",
                       ValidateLifetime = true
                   };
               });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
