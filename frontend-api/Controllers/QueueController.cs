using LabArquitetura.Infrastructure.DbContexts.Contexts;
using LabArquitetura.Infrastructure.DbContexts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabArquitetura.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class QueueController : Controller
    {
        private readonly LabArquiteturaDbContext _dbContext;

        public QueueController(LabArquiteturaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet()]
        public IEnumerable<QueueDbModel> GetMessages()
        {
            return _dbContext.Queues.AsNoTracking().Where(x => !x.Read).OrderByDescending(x => x.Id).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetBody([FromRoute] int id)
        {
            return Ok(_dbContext.Queues.AsNoTracking().First(x => x.Id.Equals(id) & !x.Read));
        }

        [HttpPost("{id}")]
        public IActionResult MarcarComoLido([FromRoute] int id)
        {
            var queue = _dbContext.Queues.First(x => x.Id.Equals(id));
            queue.Read = true;
            _dbContext.Update(queue);
            _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}