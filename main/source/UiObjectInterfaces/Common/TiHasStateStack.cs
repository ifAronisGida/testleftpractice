using System.Collections.Generic;

namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiHasStateStack
    {
        IReadOnlyDictionary<string, string> GetRawStates();
    }
}
