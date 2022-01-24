using ProvaCandidato.Data.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaCandidato.Data
{
    public class ContextoPrincipal : DbContext
    {

        const string CONNECTION_STRING = @"Server=.\;Database=provacandidato;Trusted_Connection=True;";

        public ContextoPrincipal() : base(CONNECTION_STRING) { }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<ClienteObservacao> ClienteObservacao { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
            .HasMany<ClienteObservacao>(g => g.ListaObservacao)
            .WithRequired(s => s.ObjCliente)
            .HasForeignKey<int>(s => s.ClienteId);
        }
    }
}
