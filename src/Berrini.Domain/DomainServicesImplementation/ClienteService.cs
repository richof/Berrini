// richoRichof fClienteService.cs1622:51

using System.Collections.Generic;
using System.Linq;
using Berrini.Domain.Entities;
using Berrini.Domain.EntityValidations;
using Berrini.Domain.Interfaces.Repository;
using Berrini.Domain.Interfaces.Services;
namespace Berrini.Domain.DomainServicesImplementation
{

    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteCupomRepository _clienteCupomRepository;
        private readonly ICupomRepository _cupomRepository;
        
        public ClienteService(IClienteRepository repository, 
            IClienteCupomRepository clienteCupomRepository, 
            ICupomRepository cupomRepository) : base(repository)
        {
            _clienteRepository = repository;
            _clienteCupomRepository = clienteCupomRepository;
            _cupomRepository = cupomRepository;
           
        }
        public override Cliente Adicionar(Cliente entity)
        {
            entity.ValidationResult = new ClienteValido(_clienteRepository).Validate(entity);
            if (!entity.ValidationResult.IsValid)
                return entity;

            return base.Adicionar(entity);
        }

        public IEnumerable<Cliente> Premiados()
        {
           
            var resultado = (from c in _clienteRepository.ObterTodos()
                            join cc in _clienteCupomRepository.ObterTodos() on c.Id equals cc.ClienteId
                            join cup in _cupomRepository.ObterTodos() on cc.CupomId equals cup.Id
                            where cup.PremioId != null
                            select c).ToList();
            return resultado;
        }

    }

}