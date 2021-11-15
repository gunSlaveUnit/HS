using System;
using System.ComponentModel;
using Hotel.Context;
using HS.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HS.Data
{
    public static class DbRegistrar
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<DataContext>(opt =>
            {
                var type = configuration["Type"];
                switch (type)
                {
                    case null : throw new InvalidOperationException("Database type not found");
                    default : throw new InvalidOperationException($"This type {type} doesn't support");
                    case "MSSQL":
                        opt.UseSqlServer(configuration.GetConnectionString(type));
                        break;
                }
            })
        ;
    }
}