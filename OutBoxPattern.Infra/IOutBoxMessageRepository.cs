using OutBoxPattern.Domain;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace OutBoxPattern.Infra
{
    public interface IOutBoxMessageRepository
    {        
        Task Adicionar(OutboxMessage outboxMessage);        

        DbConnection ObterConexao();
    }
}
