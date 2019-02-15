using System;
using Trumpf.Coparoo.Desktop.Waiting;

namespace HomeZone.UiObjectInterfaces.Flux
{
    public interface TiFluxApp
    {
        Wool ToolManamgementDialogExists { get; }

        TiToolManagementDialog ToolManagement { get; }

        void WaitForSynchronization( TimeSpan timeout );
        void SaveChanges();
    }
}
