using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace WebServiceUnsafe.Infrastructure
{
    public class BlobRepository : IBlobRepository
    {
        private readonly BlobSettings _blobSettings;
        private readonly BlobServiceClient _blobServiceClient;

        public BlobRepository(IOptions<BlobSettings> options)
        {
            _blobSettings = options.Value;
            _blobServiceClient = new BlobServiceClient(_blobSettings.UnsafeConnectionString);
        }

        public async IAsyncEnumerable<string> GetBlobsAsync()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_blobSettings.ContainerName);

            await foreach (var container in containerClient.GetBlobsAsync())
            {
                yield return container.Name;
            }
        }
    }
}
