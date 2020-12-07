using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebServiceManagedIdentity.Infrastructure;

namespace WebServiceManagedIdentity.Controllers
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
