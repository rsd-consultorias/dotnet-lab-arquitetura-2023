using FrontEndAPI.Core.Models;
using FrontEndAPI.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontEndAPI.Infrastructure.Repositories.Contexts;

public class LabArquiteturaDbContext : DbContext
{
    public LabArquiteturaDbContext(DbContextOptions<LabArquiteturaDbContext> options) : base(options)
    {

    }

    public DbSet<Funcionario> Funcionarios { get; set; } = null!;
    public DbSet<Queue> Queues { get; set; } = null!;
}
