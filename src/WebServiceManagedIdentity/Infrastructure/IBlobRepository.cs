using System.Collections.Generic;

namespace WebServiceManagedIdentity.Infrastructure
{
    public interface IBlobRepository
    {
        IAsyncEnumerable<string> GetBlobsAsync();
    }
}
