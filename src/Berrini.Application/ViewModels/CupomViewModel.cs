// richoRichof fCupomViewModel.cs1622:56

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;

namespace Berrini.Application.ViewModels
{

    public class CupomViewModel
    {

        public Guid Id { get; set; }
        [Display(Name ="Número do cupom")]
        public string NumeroCupom { get; set; }
        [Display(Name = "Data de criação")]
        public DateTime Criacao { get; set; }
        [Range(1,12,ErrorMessage ="O campo {0} aceita de {1} a {2} meses")]
        [Display(Name ="Validade")]
        public int MesesValidade { get; set; }
        public IEnumerable<SelectListItem> PremiosDisponiveis{get; set;}
        [Display(Name ="Prêmio")]
        public Guid? PremioId{get; set;}

        public CupomViewModel()
        {
            Id=Guid.NewGuid();
            Criacao=DateTime.Now;
        }
        [Display(Name = "Prêmio")]
        public virtual PremioViewModel Premio { get; set; }
    }

}