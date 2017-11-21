// richoRichof fPremioConf.cs1810:20
using System.Data.Entity.ModelConfiguration;
using Berrini.Domain.Entities;
namespace Berrini.Infra.Data.EntityConfigurations
{

    public class PremioConf:EntityTypeConfiguration<Premio>
    {

        public PremioConf()
        {
            HasKey(m => m.Id);
            Property(m => m.Nome).HasMaxLength(50).IsRequired();
            Property(m => m.Descricao).HasMaxLength(150).IsRequired();
            HasMany(m => m.Cupons).WithOptional(c => c.Premio);
            ToTable("Premio");
        }
        

    }

}