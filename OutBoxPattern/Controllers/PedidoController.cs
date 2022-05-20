using MediatR;
using Microsoft.AspNetCore.Mvc;
using OutBoxPattern.Command;
using System.Threading.Tasks;

namespace OutBoxPattern.Controllers
{
    public class PedidoController : Controller
    {

        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("criar-pedido")]
        public async Task<IActionResult> CriarPedido(CriarPedidoCommand pedido)
        {            
            var result = await _mediator.Send(pedido);
            if (result)
                return Ok();
            return BadRequest(result);
        }
    }
}
