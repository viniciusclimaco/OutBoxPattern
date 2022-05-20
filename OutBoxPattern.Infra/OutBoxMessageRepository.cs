using Microsoft.EntityFrameworkCore;
using OutBoxPattern.Domain;
using OutBoxPattern.Infra.Data;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace OutBoxPattern.Infra
{
    public class OutBoxMessageRepository : IOutBoxMessageRepository
    {
        private readonly PedidosContext _context;

        public OutBoxMessageRepository(PedidosContext context)
        {
            _context = context;
        }
        public DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public async Task Adicionar(OutboxMessage outboxMessage)
        {
            await _context.OutboxMessages.AddAsync(outboxMessage);
        }
    }
}
