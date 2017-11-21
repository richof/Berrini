// richoRichof fClienteViewModel.cs1619:00

using System;
using System.Collections.Generic;
using FluentValidation.Results;
namespace Berrini.Application.ViewModels
{

    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public ValidationResult ValidationResult { get; set; }
        //
        public virtual IEnumerable<ClienteCupomViewModel> CuponsCadastrados { get; set; }
    }

}