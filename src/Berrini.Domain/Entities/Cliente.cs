// richoRichof fCliente.cs1617:55

using System;
using System.Collections.Generic;
using Berrini.Domain.EntityValidations;
using FluentValidation.Results;
namespace Berrini.Domain.Entities
{

    public class Cliente
    {

        public Guid Id{get; set;}
        public string Nome{get; set;}
        public string CPF{get; set;}
        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            return true;
        }
        public Cliente()
        {
            Id=Guid.NewGuid();
            ClienteCupons=new List<ClienteCupom>();
        }

        //
        public virtual ICollection<ClienteCupom> ClienteCupons{get; set;}

    }

}