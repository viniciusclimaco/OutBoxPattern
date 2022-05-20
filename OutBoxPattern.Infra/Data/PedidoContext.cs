using Microsoft.EntityFrameworkCore;
using OutBoxPattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutBoxPattern.Infra.Data
{
    public class PedidosContext : DbContext
    {
        public PedidosContext(DbContextOptions<PedidosContext> options)
            : base(options)
        {
            
        }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

    }
}
