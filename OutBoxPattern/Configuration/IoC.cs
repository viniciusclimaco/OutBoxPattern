using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OutBoxPattern.Command;
using OutBoxPattern.Command.Handler;
using OutBoxPattern.Infra;
using OutBoxPattern.Infra.Data;

namespace OutBoxPattern.Configuration
{
    public static class IoC
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            // Commands
            services.AddScoped<IRequestHandler<CriarPedidoCommand, bool>, PedidoCommandHandler>();

            // Events
            //services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();
                        
            //services.AddScoped<IMediatorHandler, MediatorHandler>();
                        
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IOutBoxMessageRepository, OutBoxMessageRepository>();
            services.AddScoped<PedidosContext>();
        }
    }
}
