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

            //modelBuilder.Entity<AuditoriaDbModel<FuncionarioDbModel>>();
            //modelBuilder.Entity<AuditoriaDbModel<QueueDbModel>>();
            modelBuilder.ApplyConfiguration(new FuncionarioDBMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}