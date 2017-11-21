// richoRichof fCupomService.cs1622:53

using System;
using System.Linq;
using Berrini.Domain.Entities;
using Berrini.Domain.Interfaces.Repository;
using Berrini.Domain.Interfaces.Services;
namespace Berrini.Domain.DomainServicesImplementation
{

    public class CupomService:ServiceBase<Cupom>,ICupomService
    {

        private readonly IClienteCupomRepository _clienteCupomRepository;
        private readonly ICupomRepository _cupomRepository;
        public CupomService(ICupomRepository repository, IClienteCupomRepository clienteCupomRepository) : base(repository)
        {
            _clienteCupomRepository=clienteCupomRepository;
            _cupomRepository = repository;
        }

        public bool JaCadastrado(Cupom cupom)
        {
            var jaCadastrado=_clienteCupomRepository.Buscar(c => c.CupomId==cupom.Id && c.Cupom.NumeroCupom==cupom.NumeroCupom).Any();
            return jaCadastrado;
        }

        //public bool JaCadastrado(string numeroCupom)
        //{
        //    var jaCadastrado = _clienteCupomRepository.Buscar(c => c == cupom.Id).Any();
        //    return jaCadastrado;
        //}

        public Cupom Cadastrar(Cupom cupom, Guid clienteId)
        {
            if (!PodeCadastrar(clienteId))
                return cupom;

            var cupomExistente=_cupomRepository.Buscar(c => c.NumeroCupom==cupom.NumeroCupom).First();
            var clienteCupom=new ClienteCupom {ClienteId=clienteId, CupomId=cupomExistente.Id, Cadastro=DateTime.Now};
            var resultado=_clienteCupomRepository.Adicionar(clienteCupom);
            return cupom;
        }

        public bool PodeCadastrar(Guid clienteId)
        {
            var cadastrados=_clienteCupomRepository.Buscar(c => c.ClienteId==clienteId);
            return !(cadastrados.Count()>=5);
        }
        public override Cupom Adicionar(Cupom entity)
        {
            var numeroCupom=GerarNumero();
            entity.NumeroCupom=numeroCupom;
          // entity.Criacao=
            return base.Adicionar(entity);
        }

        private string GerarNumero()
        {
            Random rnd=new Random();
            string numero;
            bool existe = true;
            do
            {
                var d0=rnd.Next(1, 9).ToString();
                var d1=rnd.Next(1, 9).ToString();
                var d2=rnd.Next(1, 9).ToString();
                var d3=rnd.Next(1, 9).ToString();
                var d4=rnd.Next(1, 9).ToString();
                var d5=rnd.Next(1, 9).ToString();
                var d6=rnd.Next(1, 9).ToString();
                var d7=rnd.Next(1, 9).ToString();
                var d8=rnd.Next(1, 9).ToString();
                var d9=rnd.Next(1, 9).ToString();
                numero=d0+d1+d2+d3+d4+d5+d6+d7+d8+d9;
                var numero1=numero;
                existe=_cupomRepository.Buscar(c => c.NumeroCupom==numero1).Any();
            } while(existe);

            return numero;
        }
    }

}