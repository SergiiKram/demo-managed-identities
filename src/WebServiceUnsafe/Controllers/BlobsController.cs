using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebServiceUnsafe.Infrastructure;

namespace WebServiceUnsafe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlobsController : ControllerBase
    {
        private readonly ILogger<BlobsController> _logger;
        private readonly IBlobRepository _blobRepository;

        public BlobsController(ILogger<BlobsController> logger, IBlobRepository blobRepository)
        {
            _logger = logger;
            _blobRepository = blobRepository;
        }

        [HttpGet]
        public async IAsyncEnumerable<string> Get()
        {
            await foreach (var c in _blobRepository.GetBlobsAsync())
            {
                yield return c;
            }
        }
    }
}
