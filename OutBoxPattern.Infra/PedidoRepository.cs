using Microsoft.EntityFrameworkCore;
using OutBoxPattern.Domain;
using OutBoxPattern.Infra.Data;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace OutBoxPattern.Infra
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidosContext _context;

        public PedidoRepository(PedidosContext context)
        {
            _context = context;
        }
        public DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public async Task Adicionar(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
        }

        public async Task<int> Salvar()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
