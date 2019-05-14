using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeZone.UiObjectInterfaces.Common
{
    public interface TiHasDetailOverlay
    {
        void WaitForDetailOverlayAppear( TimeSpan? timeout = null );
        void WaitForDetailOverlayDisappear( TimeSpan? timeout = null );
        bool TryWaitForDetailOverlayAppear( TimeSpan? timeout = null );
        bool TryWaitForDetailOverlayDisappear( TimeSpan? timeout = null );
    }
}
