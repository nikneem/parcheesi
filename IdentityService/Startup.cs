using System;
using HexMaster.Parcheesi.IdentityService.Certificates;
using HexMaster.Parcheesi.IdentityService.Configuration;
using HexMaster.Parcheesi.IdentityService.Contracts.Repositories;
using HexMaster.Parcheesi.IdentityService.Data;
using HexMaster.Parcheesi.IdentityService.Services;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HexMaster.Parcheesi.IdentityService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public async void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddTransient<IResourceOwnerPasswordValidator, PasswordValidationService>();
            services.AddTransient<IProfileService, UserProfileService>();

            ConfigureIdentityServices(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            var database = Configuration.GetSection("MongoConnection:Database").Value;
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = connectionString;
                options.Database = database;
            });

            

            await new RepositorySeeder(connectionString, database).Seed();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseIdentityServer();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }


        public void ConfigureIdentityServices(IServiceCollection services)
        {
            var signCertificate = Certificate.Get();
            services.AddIdentityServer()
                .AddSigningCredential(signCertificate)
                .AddInMemoryIdentityResources(Config.GetResources())
                .AddInMemoryApiResources(Config.GetApis())
                .AddInMemoryClients(Config.GetClients())
                .AddProfileService<UserProfileService>();
        }
    }
}
