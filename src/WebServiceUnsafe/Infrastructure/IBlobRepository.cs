using System.Collections.Generic;

namespace WebServiceUnsafe.Infrastructure
{
    public interface IBlobRepository
    {
        IAsyncEnumerable<string> GetBlobsAsync();
    }
}
