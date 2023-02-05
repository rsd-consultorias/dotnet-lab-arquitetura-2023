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
    //private readonly ILogger _logger;

    public QueueController(LabArquiteturaDbContext dbContext
        //, ILogger<QueueController> logger
        )
    {
        _dbContext = dbContext;
        //_logger = logger;
    }

    [HttpGet()]
    public IEnumerable<Queue> GetMessages()
    {
        return _dbContext.Queues.Where(x => !x.Read).ToList<Queue>();
    }

    [HttpGet("{id}")]
    public IActionResult GetBody([FromRoute] int id)
    {
        return Ok(_dbContext.Queues.First(x => x.Id.Equals(id) & !x.Read));
    }

    [HttpPost("{id}")]
    public IActionResult MarcarComoLido([FromRoute] int id)
    {
        var queue = _dbContext.Queues.First(x => x.Id.Equals(id));
        queue.Read = true;
        _dbContext.Update(queue);
        _dbContext.SaveChanges();
        return Ok();
    }
}