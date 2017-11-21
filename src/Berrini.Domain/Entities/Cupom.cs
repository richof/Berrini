// richoRichof fCupom.cs1617:59

using System;
using FluentValidation.Results;
namespace Berrini.Domain.Entities
{

    public class Cupom
    {

        public Guid Id{get; set;}
        public string NumeroCupom{get; set;}
        public DateTime Criacao{get; set;}
        public int MesesValidade{get; set;}
        public Guid? PremioId { get; set; }

        public ValidationResult ValidationResult{get; set;}
        public Cupom()
        {
            Id=Guid.NewGuid();
            Criacao=DateTime.Now;
        }
        public virtual Premio Premio { get; set; }
    }

}