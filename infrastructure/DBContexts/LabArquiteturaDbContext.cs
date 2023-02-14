using LabArquitetura.Core.Models;
using LabArquitetura.Infrastructure.DBContexts.Mappings;
using LabArquitetura.Infrastructure.DBContexts.Models;
using Microsoft.EntityFrameworkCore;

namespace LabArquitetura.Infrastructure.DBContexts.Contexts
{

    public class LabArquiteturaDbContext : DbContext
    {
        public LabArquiteturaDbContext(DbContextOptions<LabArquiteturaDbContext> options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public DbSet<QueueDbModel> Queues { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfiguration(new FuncionarioMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new DocumentoMapping());
            modelBuilder.ApplyConfiguration(new EventoFolhaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}