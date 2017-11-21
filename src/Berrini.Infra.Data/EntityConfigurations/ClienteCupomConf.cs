// richoRichof fClienteCupomConf.cs1619:23

using System.Data.Entity.ModelConfiguration;
using Berrini.Domain.Entities;
namespace Berrini.Infra.Data.EntityConfigurations
{

    public class ClienteCupomConf:EntityTypeConfiguration<ClienteCupom>
    {

        public ClienteCupomConf()
        {
            HasKey(m => m.Id);
           
        }
    }

}