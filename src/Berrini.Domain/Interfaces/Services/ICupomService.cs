// richoRichof fICupomService.cs1622:52

using System;
using Berrini.Domain.Entities;
namespace Berrini.Domain.Interfaces.Services
{

    public interface ICupomService:IServiceBase<Cupom>
    {

        bool JaCadastrado(Cupom cupom);
        //bool JaCadastrado(string numeroCupom);

        Cupom Cadastrar(Cupom cupom, Guid clienteId);

        bool PodeCadastrar(Guid clienteId);

    }

}