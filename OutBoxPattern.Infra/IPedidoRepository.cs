using OutBoxPattern.Domain;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace OutBoxPattern.Infra
{
    public interface IPedidoRepository
    {        
        Task Adicionar(Pedido pedido);

        Task<int> Salvar();

        DbConnection ObterConexao();
    }
}
