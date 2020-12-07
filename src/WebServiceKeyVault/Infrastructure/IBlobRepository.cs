using System.Collections.Generic;

namespace WebServiceKeyVault.Infrastructure
{
    public interface IBlobRepository
    {
        IAsyncEnumerable<string> GetBlobsAsync();
    }
}
