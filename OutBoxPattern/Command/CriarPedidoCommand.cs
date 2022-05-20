using MediatR;

namespace OutBoxPattern.Command
{
    public class CriarPedidoCommand : IRequest<bool>
    {   
        public string Produto { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }        
    }
}
