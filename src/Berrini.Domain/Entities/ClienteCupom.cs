// richoRichof fCuponsDoCliente.cs1618:17

using System;
namespace Berrini.Domain.Entities
{

    public class ClienteCupom
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid CupomId { get; set; }

        public DateTime Cadastro { get; set; }
        //
        public virtual Cliente Cliente { get; set; }
        public virtual Cupom Cupom { get; set; }

        public ClienteCupom()
        {
            Id = Guid.NewGuid();
            Cadastro = DateTime.Now;
        }
    }

}