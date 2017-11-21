// richoRichof fCupomAppService.cs1623:46

using System;
using System.Collections.Generic;
using Berrini.Application.AppInterfaces;
using Berrini.Application.ViewModels;
using Berrini.Domain.Entities;
using Berrini.Domain.Interfaces.Services;
using System.Linq;
using AutoMapper;
namespace Berrini.Application.AppServicesImplementation
{

    public class CupomAppService : AppServiceBase<CupomViewModel, Cupom>, ICupomAppService
    {

        private readonly ICupomService _cupomService;
        private readonly IClienteCupomService _clienteCupomService;
        public CupomAppService(ICupomService service, IClienteCupomService clienteCupomService) : base(service)
        {
            _cupomService = service;
            _clienteCupomService=clienteCupomService;
        }
        public override CupomViewModel Adicionar(CupomViewModel viewModel)
        {

            return base.Adicionar(viewModel);
        }
       
        public override CupomViewModel Atualizar(CupomViewModel viewModel)
        {
            if (_cupomService.JaCadastrado(ToEntity(viewModel)))
            {

                return viewModel;
            }
            return base.Atualizar(viewModel);
        }
        public override void Remover(Guid id)
        {
            if (!_cupomService.JaCadastrado(ToEntity(ObterPorId(id))))
                base.Remover(id);
        }

        public IEnumerable<CupomViewModel> ObterPorCliente(Guid id)
        {
            var cuponsCadastrados=_clienteCupomService.Buscar(c => c.ClienteId==id).ToList();
            var cuponsDoCliente=
            (from c in _cupomService.ObterTodos()
             join cc in cuponsCadastrados on c.Id equals cc.CupomId
             where cc.ClienteId==id
             select c).Select(ToViewModel);
            return cuponsDoCliente;
        }

        public CadastroCupomViewModel Cadastrar(CadastroCupomViewModel cupomViewModel, Guid clienteId)
        {

            var cupom=_cupomService.Buscar(c => c.NumeroCupom==cupomViewModel.NumeroCupom).FirstOrDefault();
            if (_cupomService.JaCadastrado(cupom))
                return cupomViewModel;

            if(_cupomService.PodeCadastrar(clienteId) && ExisteCupom(cupom.NumeroCupom))
                return Mapper.Map<Cupom,CadastroCupomViewModel>( _cupomService.Cadastrar(cupom, clienteId));

            return cupomViewModel;

        }

        public bool JaCadastrado(CupomViewModel cupomViewModel)
        {
            var cupom=_cupomService.Buscar(c => c.NumeroCupom==cupomViewModel.NumeroCupom).FirstOrDefault();
            return _cupomService.JaCadastrado(cupom);
        }

        public bool JaCadastrado(CadastroCupomViewModel cupomViewModel)
        {
            var cupom = _cupomService.Buscar(c => c.NumeroCupom == cupomViewModel.NumeroCupom).FirstOrDefault();
            return _cupomService.JaCadastrado(cupom);
        }

        public bool PodeCadastrar(Guid clienteId)
        {
            return _cupomService.PodeCadastrar(clienteId);
        }

        public IEnumerable<ClienteCupomViewModel> CuponsCadastrados()
        {
            var cuponsCadastrados=_clienteCupomService.ObterTodos().Select(ConverterParaClienteCupomViewModel).ToList();

            return cuponsCadastrados;
        }

        private ClienteCupomViewModel ConverterParaClienteCupomViewModel(ClienteCupom clienteCupom)
        {
            var resultado=Mapper.Map<ClienteCupom, ClienteCupomViewModel>(clienteCupom);
            return resultado;
        }
        public bool ExisteCupom(string numeroCupom)
        {
            var existeCupom=_cupomService.Buscar(c => c.NumeroCupom==numeroCupom).Any();
            return existeCupom;

        }

    }

}