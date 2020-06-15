using Dados.Contexto;
using Dados.Repository;
using Microsoft.Extensions.DependencyInjection;
using Negocio.Interfaces;
using Negocio.Notifications;
using Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dependencias
{
    public static class ResolveInjectionDependency
    {
        public static IServiceCollection ResolveDepencencies(this IServiceCollection services)
        {
            services.AddScoped<ModeloDbContext>();

            services.AddScoped<IEntidadeRepository, EntidadeRepository>();

            services.AddScoped<IEntidadeService, EntidadeService>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
