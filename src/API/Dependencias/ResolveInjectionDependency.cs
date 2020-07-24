using Dados.Contexto;
using Dados.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Negocio.Interfaces;
using Negocio.Notifications;
using Negocio.Services;

namespace API.Dependencias
{
    public static class ResolveInjectionDependency
    {
        public static IServiceCollection ResolveDepencencies(this IServiceCollection services)
        {
            services.AddScoped<ModeloDbContext>();

            services.AddScoped<IEntidadeRepository, EntidadeRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();

            services.AddScoped<IEntidadeService, EntidadeService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<ISolicitacaoService, SolicitacaoService>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
