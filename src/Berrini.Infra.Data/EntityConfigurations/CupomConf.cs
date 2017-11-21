// richoRichof fCupomConf.cs1618:32

using Berrini.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Berrini.Infra.Data.EntityConfigurations
{

    public class CupomConf : EntityTypeConfiguration<Cupom>
    {

        public CupomConf()
        {
            HasKey(m => m.Id);
            Property(m => m.NumeroCupom).HasMaxLength(10).IsRequired();
           
            Ignore(m => m.ValidationResult);
            ToTable("Cupom");

        }
    }

}
/*
  public Guid Id{get; set;}
        public string NumeroCupom{get; set;}
        public DateTime Criação{get; set;}
        public int MesesValidade{get; set;}
     */
