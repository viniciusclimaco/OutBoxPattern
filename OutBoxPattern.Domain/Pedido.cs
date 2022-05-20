using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutBoxPattern.Domain
{
    public class Pedido
    {
        public Pedido(string produto, decimal desconto, decimal valorTotal)
        {
            Produto = produto;
            Desconto = desconto;
            ValorTotal = valorTotal;
        }

        protected Pedido() { }

        public Guid Id { get; set; }
        public string Produto { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataCadastro { get; set; }        
    }
}
