// richoRichof fClientesPremiadosViewModel.cs2011:14

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Berrini.Domain.Entities;
namespace Berrini.Application.ViewModels
{

    public class ClientePremiadoViewModel
    {

        public Guid Id{get; set;}
        public string Nome{get; set;}
        public string CPF{get; set;}
        //public IEnumerable<Premio> Premios { get; set; }
        [Display(Name ="Prêmio")]
        public PremioViewModel Premio{get; set;}
        public ClientePremiadoViewModel()
        {
            //Premios=new List<Premio>();
        }
    }

}