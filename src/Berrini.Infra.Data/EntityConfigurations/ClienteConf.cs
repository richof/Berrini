// richoRichof fClienteConf.cs1618:11

using System.Data.Entity.ModelConfiguration;
using Berrini.Domain.Entities;
namespace Berrini.Infra.Data.EntityConfigurations
{

    public class ClienteConf : EntityTypeConfiguration<Cliente>
    {

        public ClienteConf()
        {
            HasKey(m => m.Id);
            Property(m => m.Nome).HasMaxLength(100).IsRequired();
            Property(m => m.CPF).HasMaxLength(11).IsRequired();
            HasMany(m => m.ClienteCupons).WithRequired(c => c.Cliente);
            Ignore(m => m.ValidationResult);
            ToTable("Cliente");
        }
    }

}