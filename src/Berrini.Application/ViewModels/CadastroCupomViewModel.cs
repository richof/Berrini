// richoRichof fCadastroCupomViewModel.cs2019:30

using System;
using System.ComponentModel.DataAnnotations;

namespace Berrini.Application.ViewModels
{

    public class CadastroCupomViewModel
    {
        public Guid Id { get; set; }
        [StringLength(10, ErrorMessage = "O {0} deve ter {1} numeros")]
        [Display(Name = "Numero do cupom")]
        [RegularExpression(@"^\d{10}$", ErrorMessage ="O campo {0} deve conter 10 números")]
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        
        public string NumeroCupom{get; set;}

    }

}