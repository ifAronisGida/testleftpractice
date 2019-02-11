using HomeZone.UiObjectInterfaces.Flux;
using SmartBear.TestLeft;
using System;
using System.Threading;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.Waiting;

namespace HomeZone.UiObjects.PageObjects.Flux
{
    public class TcFluxApp : ProcessObject, TiFluxApp
    {
        private readonly Lazy<TcToolManagementDialog> mToolManagementDialog;

        public TcFluxApp( string processname, IDriver driver ) : base( processname )
        {
            Driver = driver;
            mToolManagementDialog = new Lazy<TcToolManagementDialog>( On<TcToolManagementDialog> );
        }

        public TiToolManagementDialog ToolManagement => On<TcToolManagementDialog>();

        public Wool ToolManamgementDialogExists => mToolManagementDialog.Value.Exists;

        public void WaitForSynchronization( TimeSpan timeout )
        {
            Thread.Sleep( timeout );
        }
    }
}
