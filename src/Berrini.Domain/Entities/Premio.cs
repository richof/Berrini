// richoRichof fPremio.cs1810:02

using System;
using System.Collections.Generic;

namespace Berrini.Domain.Entities
{

    public class Premio
    {

        public Guid Id{get; set;}
        public string Nome{get; set;}
        public string Descricao{get; set;}

        public Premio()
        {
            Id=Guid.NewGuid();
            Cupons=new List<Cupom>();
        }
        //
        public virtual ICollection<Cupom> Cupons{get; set;}
        

    }

}