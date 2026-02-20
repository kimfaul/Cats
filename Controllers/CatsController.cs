using Microsoft.AspNetCore.Mvc;

namespace Cats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Tabby", "Calico", "Russian Blue", "Persian", "Bombay", "Siamese"
        };

        private readonly ILogger<CatsController> _logger;

        public CatsController(ILogger<CatsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCats")]
        public IEnumerable<Cats> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Cats
            {
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
