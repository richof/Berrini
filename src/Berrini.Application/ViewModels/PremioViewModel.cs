// richoRichof fPremioViewModel.cs1810:34

using System;
using System.ComponentModel.DataAnnotations;
namespace Berrini.Application.ViewModels
{

    public class PremioViewModel
    {

        public Guid Id { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        public PremioViewModel()
        {
            Id=Guid.NewGuid();
        }
    }

}