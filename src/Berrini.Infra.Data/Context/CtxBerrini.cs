// richoRichof fCtxBerrini.cs1619:09

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Berrini.Domain.Entities;
using Berrini.Infra.Data.EntityConfigurations;
namespace Berrini.Infra.Data.Context
{

    public class CtxBerrini:DbContext
    {

        public CtxBerrini()
            :base("BerriniConnection")
        {
            
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cupom> Cupons{get; set;}
        public DbSet<ClienteCupom> ClienteCupons{get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(m => m.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(m => m.HasMaxLength(200));
            modelBuilder.Configurations.Add(new ClienteConf());
            modelBuilder.Configurations.Add(new CupomConf());
            modelBuilder.Configurations.Add(new ClienteCupomConf());
               
            base.OnModelCreating(modelBuilder);
        }

    }

}