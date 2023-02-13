using LabArquitetura.Core.Models;
using LabArquitetura.Infrastructure.DbContexts.Mappings;
using LabArquitetura.Infrastructure.DbContexts.Models;
using Microsoft.EntityFrameworkCore;

namespace LabArquitetura.Infrastructure.DbContexts.Contexts
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

            base.OnModelCreating(modelBuilder);
        }
    }
}