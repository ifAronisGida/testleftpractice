using System;

namespace HomeZone.UiObjects
{
    public class TcPageObjectSettings
    {
        private TcPageObjectSettings()
        {
        }

        public static TcPageObjectSettings Instance { get; } = new TcPageObjectSettings();

        public TimeSpan MachineFirstImportTimeout { get; set; } = TimeSpan.FromSeconds( 120 );

        public TimeSpan SavingTimeout { get; set; } = TimeSpan.FromSeconds( 60 );

        public TimeSpan MaterialOverlayAppearTimeout { get; set; } = TimeSpan.FromSeconds( 20 );

        public TimeSpan MaterialOverlayDisappearTimeout { get; set; } = TimeSpan.FromSeconds( 60 );

        public TimeSpan MachineOverlayAppearTimeout { get; set; } = TimeSpan.FromSeconds( 20 );

        public TimeSpan MachineOverlayDisappearTimeout { get; set; } = TimeSpan.FromSeconds( 60 );

        public TimeSpan PartOverlayAppearTimeout { get; set; } = TimeSpan.FromSeconds( 10 );

        public TimeSpan PartOverlayDisappearTimeout { get; set; } = TimeSpan.FromSeconds( 90 );
    }
}
