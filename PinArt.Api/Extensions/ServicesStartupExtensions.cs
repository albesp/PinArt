using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PinArt.Core.Interfaces;
using PinArt.Core.Services;
using PinArt.Infrastructure.Data;
using PinArt.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Core.Services;

namespace PinArt.Api.Extensions
{
    public static class ServicesStartupExtensions
    {

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PinArtDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("PinArtConnectionString"))
        );

            return services;
        }

        public static IServiceCollection ConfigureDIServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IArtistaService, ArtistaService>();
            services.AddTransient<IPaisService, PaisService>();
            services.AddTransient<ISecurityService, SecurityService>();

            return services;
        }

        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader());
            //});

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod(); ;
                    });
            });

            return services;
        }
    }
}
