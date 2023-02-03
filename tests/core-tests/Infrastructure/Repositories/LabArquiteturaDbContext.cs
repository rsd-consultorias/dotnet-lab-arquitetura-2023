using FrontEndAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontEndAPI.Infrastructure.Repositories.Contexts;

public class LabArquiteturaDbContext : DbContext
{
    public LabArquiteturaDbContext(DbContextOptions<LabArquiteturaDbContext> options) : base(options)
    {

    }

    public DbSet<Funcionario> Funcionarios { get; set; } = null!;
}