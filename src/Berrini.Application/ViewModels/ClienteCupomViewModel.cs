// richoRichof fClienteCupomViewModel.cs1900:01

using System;
using Berrini.Domain.Entities;
namespace Berrini.Application.ViewModels
{

    public class ClienteCupomViewModel
    {

        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid CupomId { get; set; }

        public DateTime Cadastro { get; set; }
        //
        public virtual ClienteViewModel Cliente { get; set; }
        public virtual CupomViewModel Cupom { get; set; }

    }

}