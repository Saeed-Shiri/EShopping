﻿using Discount.Application.Abstractions;
using Discount.Core.Repositories;
using Discount.Infrastructure.Persistence;
using Discount.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IDatabaseConnectionFactory, NpgsqlConnectionFactory>();
        services.AddSingleton<IDatabaseFactory, NpgsqlDatabaseFactory>();
        services.AddScoped<IDiscountRepository, DiscountRepository>();
        return services;
    }
}
