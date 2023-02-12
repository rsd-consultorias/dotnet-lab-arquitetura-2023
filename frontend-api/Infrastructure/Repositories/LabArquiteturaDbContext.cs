using LabArquitetura.Core.Models;
using LabArquitetura.Infrastructure.Repositories.Mappings;
using LabArquitetura.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace LabArquitetura.Infrastructure.Repositories.Contexts
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