using FrontEndAPI.Infrastructure.Repositories.Contexts;
using FrontEndAPI.Infrastructure.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontEndAPI.Controllers;

[ApiController]
// [Authorize]
[Route("api/v1/[controller]")]
public class QueueController : Controller
{
    private readonly LabArquiteturaDbContext _dbContext;

    public QueueController(LabArquiteturaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet()]
    public IEnumerable<Queue> GetMessages()
    {
        return _dbContext.Queues.ToList<Queue>();
    }
}