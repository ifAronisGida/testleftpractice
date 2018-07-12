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
        /// Gets the timeout for the material save overlay appearance.
        /// </summary>
        /// <value>
        /// The material save overlay appear timeout.
        /// </value>
        public static TimeSpan MaterialSaveOverlayAppearTimeout
        {
            get
            {
                return TimeSpan.FromSeconds( 10 );
            }
        }

        /// <summary>
        /// Gets the timeout for the material save overlay disappearance.
        /// </summary>
        /// <value>
        /// The material save overlay disappear timeout.
        /// </value>
        public static TimeSpan MaterialSaveOverlayDisappearTimeout
        {
            get
            {
                return TimeSpan.FromSeconds( 30 );
            }
        }

        /// <summary>
        /// Gets the timeout for the machine save overlay appearance.
        /// </summary>
        /// <value>
        /// The machine save overlay appear timeout.
        /// </value>
        public static TimeSpan MachineSaveOverlayAppearTimeout
        {
            get
            {
                return TimeSpan.FromSeconds( 10 );
            }
        }

        /// <summary>
        /// Gets the timeout for the machine save overlay disappearance.
        /// </summary>
        /// <value>
        /// The machine save overlay disappear timeout.
        /// </value>
        public static TimeSpan MachineSaveOverlayDisappearTimeout
        {
            get
            {
                return TimeSpan.FromSeconds( 30 );
            }
        }

        /// <summary>
        /// Gets the timeout for the part save overlay appearance.
        /// </summary>
        /// <value>
        /// The part import overlay appear timeout.
        /// </value>
        public static TimeSpan PartImportOverlayAppearTimeout
        {
            get
            {
                return TimeSpan.FromSeconds( 5 );
            }
        }

        /// <summary>
        /// Gets the timeout for the part save overlay disappearance.
        /// </summary>
        /// <value>
        /// The part import overlay disappear timeout.
        /// </value>
        public static TimeSpan PartImportOverlayDisappearTimeout
        {
            get
            {
                return TimeSpan.FromSeconds( 90 );
            }
        }

        /// <summary>
        /// Gets timeout for saving items.
        /// </summary>
        /// <value>
        /// The saving timeout.
        /// </value>
        public static TimeSpan SavingTimeout => TimeSpan.FromSeconds( 20 );

        /// <summary>
        /// Gets timeout for starting Flux.
        /// </summary>
        /// <value>
        /// The Flux starting timeout.
        /// </value>
        public static TimeSpan FluxStartTimeout => TimeSpan.FromSeconds( 40 );
    }
}
