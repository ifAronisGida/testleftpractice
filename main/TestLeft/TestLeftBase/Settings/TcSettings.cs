using System;

namespace TestLeft.TestLeftBase.Settings
{
    /// <summary>
    /// This class contains the settings used by the UI tests.
    /// </summary>
    public class TcSettings
    {
        /// <summary>
        /// Gets the name prefix. This can be used to identify test items for example.
        /// </summary>
        /// <value>
        /// The name prefix.
        /// </value>
        public static string NamePrefix => @"UIT_";

        /// <summary>
        /// Gets the name of the HomeZone process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public static string HomeZoneProcessName => @"Trumpf.TruTops.Control.Shell";

        /// <summary>
        /// Gets the name of the Flux process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public static string FluxProcessName => @"Flux";

        /// <summary>
        /// Gets the HomeZone program path.
        /// </summary>
        /// <value>
        /// The program path.
        /// </value>
        public static string ProgramPath => @"C:\Program Files\TRUMPF\TruTops\Client\Control";

        /// <summary>
        /// Gets the timeout for the material overlay appearance.
        /// </summary>
        /// <value>
        /// The material overlay appear timeout.
        /// </value>
        public static TimeSpan MaterialOverlayAppearTimeout => TimeSpan.FromSeconds( 10 );

        /// <summary>
        /// Gets the timeout for the material overlay disappearance.
        /// </summary>
        /// <value>
        /// The material overlay disappear timeout.
        /// </value>
        public static TimeSpan MaterialOverlayDisappearTimeout => TimeSpan.FromSeconds( 30 );

        /// <summary>
        /// Gets the timeout for the machine overlay appearance.
        /// </summary>
        /// <value>
        /// The machine overlay appear timeout.
        /// </value>
        public static TimeSpan MachineOverlayAppearTimeout => TimeSpan.FromSeconds( 10 );

        /// <summary>
        /// Gets the timeout for the machine overlay disappearance.
        /// </summary>
        /// <value>
        /// The machine overlay disappear timeout.
        /// </value>
        public static TimeSpan MachineOverlayDisappearTimeout => TimeSpan.FromSeconds( 30 );

        /// <summary>
        /// Gets the timeout for the part overlay appearance.
        /// </summary>
        /// <value>
        /// The part overlay appear timeout.
        /// </value>
        public static TimeSpan PartOverlayAppearTimeout => TimeSpan.FromSeconds( 5 );

        /// <summary>
        /// Gets the timeout for the part overlay disappearance.
        /// </summary>
        /// <value>
        /// The part overlay disappear timeout.
        /// </value>
        public static TimeSpan PartOverlayDisappearTimeout => TimeSpan.FromSeconds( 90 );

        /// <summary>
        /// Gets timeout for saving items.
        /// </summary>
        /// <value>
        /// The saving timeout.
        /// </value>
        public static TimeSpan SavingTimeout => TimeSpan.FromSeconds( 60 );

        /// <summary>
        /// Gets timeout for starting Flux.
        /// </summary>
        /// <value>
        /// The Flux starting timeout.
        /// </value>
        public static TimeSpan FluxStartTimeout => TimeSpan.FromSeconds( 60 );

        /// <summary>
        /// Gets timeout for starting Design.
        /// </summary>
        /// <value>
        /// The Design starting timeout.
        /// </value>
        public static TimeSpan DesignStartTimeout => TimeSpan.FromSeconds( 40 );

        /// <summary>
        /// Gets timeout for starting Cut.
        /// </summary>
        /// <value>
        /// The Cut starting timeout.
        /// </value>
        public static TimeSpan CutStartTimeout => TimeSpan.FromSeconds( 40 );
    }
}
