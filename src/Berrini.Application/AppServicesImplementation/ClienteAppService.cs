// richoRichof fClienteAppService.cs1623:44

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Berrini.Application.AppInterfaces;
using Berrini.Application.ViewModels;
using Berrini.Domain.Entities;
using Berrini.Domain.Interfaces.Services;
namespace Berrini.Application.AppServicesImplementation
{

    public class ClienteAppService:AppServiceBase<ClienteViewModel,Cliente>,IClienteAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IPremioService _premioService;
        private readonly IClienteCupomService _clienteCupomService;
        private readonly ICupomService _cupomService;
        public ClienteAppService(IClienteService service, 
            IPremioService premioService,
            IClienteCupomService clienteCupomService,
            ICupomService cupomService) : base(service)
        {
            _clienteService=service;
            _premioService=premioService;
            _clienteCupomService=clienteCupomService;
            _cupomService=cupomService;
        }

        public bool CadastrarCliente(Guid id, string nome, string cpf)
        {
            var cliente=new Cliente {Id=id, Nome=nome, CPF=cpf};
            var resultado=_clienteService.Adicionar(cliente);
            if (!resultado.ValidationResult.IsValid)
                return false;
            return true;

        }

        public IEnumerable<ClientePremiadoViewModel> Premiados()
        {
            var config=new MapperConfiguration(cfg => {cfg.CreateMissingTypeMaps=true; cfg.AllowNullCollections=true; });
            var mapper = config.CreateMapper();
            var premios=_premioService.ObterTodos().ToList();
         
            var resultado=(from c in _clienteService.ObterTodos()
                           join cc in _clienteCupomService.ObterTodos() on c.Id equals cc.ClienteId
                           join cup in _cupomService.ObterTodos() on cc.CupomId equals cup.Id
                           join p in premios on cup.PremioId equals p.Id
                           where cup.PremioId!=null
                           select new {
                               c.Id, c.Nome,
                               c.CPF,
                               Premio = p //premios.Where(pr=>pr.Id==p.Id)
                           }).Select(mapper.Map<ClientePremiadoViewModel>).OrderBy(cliente => cliente.Id).ToList();
            return resultado;
        }

        

        public override ClienteViewModel Adicionar(ClienteViewModel viewModel)
        {
            var resultado=_clienteService.Adicionar(ToEntity(viewModel));
            if(!resultado.ValidationResult.IsValid)
                return ToViewModel(resultado);

            return viewModel;
        }

    }

}