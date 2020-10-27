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


            return services;
        }
    }
}
