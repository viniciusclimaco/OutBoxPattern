using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OutBoxPattern.Domain;
using OutBoxPattern.Infra;

namespace OutBoxPattern.Command.Handler
{
    public class PedidoCommandHandler : IRequestHandler<CriarPedidoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IOutBoxMessageRepository _outBoxMessageRepository;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository,
                                    IOutBoxMessageRepository outBoxMessageRepository)
        {            
            _pedidoRepository = pedidoRepository;
            _outBoxMessageRepository = outBoxMessageRepository;
        }

        public async Task<bool> Handle(CriarPedidoCommand message, CancellationToken cancellationToken)
        {   
            var pedido = Map(message);
            var outbox = ToOutboxMessage(message);

            await _pedidoRepository.Adicionar(pedido);
            await _outBoxMessageRepository.Adicionar(outbox);

            if (_pedidoRepository.Salvar().Result > 0)
                return true;
            return false;
        }

        private Pedido Map(CriarPedidoCommand message)
        {            
            var pedido = new Pedido(message.Produto, message.Desconto, message.ValorTotal);            
            return pedido;
        }

        private OutboxMessage ToOutboxMessage(CriarPedidoCommand message)
        {
            var pedido = new OutboxMessage("Pedido do produto " + message.Produto + " realizado com sucesso.");
            return pedido;
        }
    }
}