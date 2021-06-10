using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using keeprserver.server.Repositories;
using keeprserver.server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;

namespace keeprserver.server
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
      //NOTE I added for Final
      ConfigureCors(services);
      ConfigureAuth(services);
      // end
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "keeprserver.server", Version = "v1" });
      });

      services.AddScoped<IDbConnection>(x => CreateDbConnection());

      // REPOS
      services.AddScoped<ProfilesRepository>();
      services.AddTransient<VaultsRepository>();
      services.AddTransient<KeepsRepository>();
      services.AddTransient<VaultKeepsRepository>();
      // Business Logic
      services.AddScoped<ProfilesService>();
      services.AddTransient<VaultsService>();
      services.AddTransient<KeepsService>();
      services.AddTransient<VaultKeepsService>();
    }
    //NOTE I added for Final/Auth
    private void ConfigureCors(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("CorsDevPolicy", builder =>
              {
                builder
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials()
                      .WithOrigins(new string[]{
                        "http://localhost:8080", "http://localhost:8081"
                  });
              });
      });
    }


    private void ConfigureAuth(IServiceCollection services)
    {
      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options =>
      {
        // NOTE this must match the object structure in appsettings.json
        options.Authority = $"https://{Configuration["AUTH0_DOMAIN"]}/";
        options.Audience = Configuration["AUTH0_AUDIENCE"];
      });

    }

    private IDbConnection CreateDbConnection()
    {
      // NOTE this must match the object structure in appsettings.json
      string connectionString = Configuration["CONNECTION_STRING"];
      return new MySqlConnection(connectionString);
    }
    // end




    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "keeprserver.server v1"));
        //NOTE I added for Final
        app.UseCors("CorsDevPolicy");
        //   end
      }

      app.UseHttpsRedirection();

      // NOTE I added for Final use to serve your built client
      app.UseDefaultFiles();
      app.UseStaticFiles();
      // end
      app.UseRouting();

      //NOTE I added for Final
      app.UseAuthentication();
      //   end

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
