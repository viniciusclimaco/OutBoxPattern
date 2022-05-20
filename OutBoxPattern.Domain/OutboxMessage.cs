using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutBoxPattern.Domain
{
    public class OutboxMessage
    {
        private OutboxMessage()
        {
        }

        public OutboxMessage(string mensagem)
        {
            Mensagem = mensagem;
            Enviado = false;
            DataEnvio = null;
        }

        public void Processado()
        {
            Enviado = true;
            DataEnvio = DateTime.Now;
        }
        public Guid Id { get; set; }        
        public string Mensagem { get; set; }

        public bool Enviado { get; set; }
        public DateTime? DataEnvio { get; set; }
    }
}


