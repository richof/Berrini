// richoRichof fClienteValido.cs1709:06

using System.Linq;
using Berrini.Domain.Entities;
using Berrini.Domain.Interfaces.Repository;
using FluentValidation;

namespace Berrini.Domain.EntityValidations
{

    public class ClienteValido:AbstractValidator<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteValido(IClienteRepository clienteRepository)
        {
            _clienteRepository=clienteRepository;
            //regras

            RuleFor(m => m.CPF).Must(CpfUnico).WithMessage("O CPF já existe no sistema");
        }

        private bool CpfUnico(string cpf)
        {
           var existe =_clienteRepository.Buscar(c => c.CPF==cpf).Any();
            return !existe;
        }

    }

}