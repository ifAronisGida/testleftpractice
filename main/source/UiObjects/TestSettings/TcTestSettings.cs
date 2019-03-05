using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HomeZone.UiObjects.TestSettings
{
    /// <summary>
    /// This class contains the settings used by the UI tests.
    /// </summary>
    public class TcTestSettings
    {
        private readonly TestContext mTestContext;

        public TcTestSettings( TestContext testContext )
        {
            mTestContext = testContext;
        }

        public string HtmlReportPath => GetString( "HtmlReportPath", null );

        public string Product => GetString( "Product", "HomeZone" );

        public string Version => GetString( "Version", "x.x.x.x" );

        public string Context => GetString( "Context", Environment.MachineName );

        public string Process => GetString( "Process", "Developer test" );

        public string Remarks => GetString( "Remarks", "(none)" );

        public bool FactsHubEnabled => GetBool( "FactsHubEnabled", true );
        public string FactsHubAddress => GetString( "FactsHubAddress", "http://srv01facts111:5000" );       //$"http://{Context}:5000"

        public bool ScreenRecorderEnabled => GetBool( "ScreenRecorderEnabled", false );

        public string TestedAppName => GetString( "TestedAppName", "Trumpf.TruTops.Control.Shell" );
        public string TestedAppPath => GetString( "TestedAppPath", @"C:\Program Files\TRUMPF\TruTops\Client\Control" );

        public TeAppLanguage ApplicationLanguage
        {
            get
            {
                if( Enum.TryParse( GetString( "ApplicationLanguage", "German" ), true, out TeAppLanguage language ) )
                {
                    switch( language )
                    {
                        case TeAppLanguage.English:
                            return TeAppLanguage.English;

                        case TeAppLanguage.German:
                            return TeAppLanguage.German;

                        case TeAppLanguage.Hungarian:
                            return TeAppLanguage.Hungarian;
                    }
                }

                return TeAppLanguage.English;
            }
        }

        /// <summary>
        /// Gets the name prefix. This can be used to identify test items for example.
        /// </summary>
        /// <value>
        /// The name prefix.
        /// </value>
        public string NamePrefix => GetString( "NamePrefix", "UIT_" );

        /// <summary>
        /// Gets the name of the Flux process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public string FluxProcessName => GetString( "FluxProcessName", "Flux" );

        /// <summary>
        /// Gets timeout for the first import of the machine templates.
        /// </summary>
        /// <value>
        /// The machine first import timeout.
        /// </value>
        public TimeSpan MachineFirstImportTimeout => TimeSpan.FromSeconds( GetInt( "MachineFirstImportTimeout", 120 ) );

        /// <summary>
        /// Gets timeout for starting Design.
        /// </summary>
        /// <value>
        /// The Design starting timeout.
        /// </value>
        public TimeSpan DesignStartTimeout => TimeSpan.FromSeconds( GetInt( "DesignStartTimeout", 80 ) );

        /// <summary>
        /// Gets timeout for starting Cut.
        /// </summary>
        /// <value>
        /// The Cut starting timeout.
        /// </value>
        public TimeSpan CutStartTimeout => TimeSpan.FromSeconds( GetInt( "CutStartTimeout", 40 ) );

        /// <summary>
        /// Gets timeout for starting Flux.
        /// </summary>
        /// <value>
        /// The Flux starting timeout.
        /// </value>
        public TimeSpan FluxStartTimeout => TimeSpan.FromSeconds( GetInt( "FluxStartTimeout", 15 ) );

        /// <summary>
        /// Gets timeout for starting Flux with a geometry which has not been boostet previously
        /// </summary>
        /// <value>
        /// The Flux boost and starting timeout
        /// </value>
        public TimeSpan FluxBoostAndStartTimeout => TimeSpan.FromSeconds( GetInt( "FluxBoostAndStartTimeout", 60 ) );

        /// <summary>
        /// Gets timeout for syncing data between Flux and Boost
        /// </summary>
        /// <value>
        /// The Sync timeout
        /// </value>
        public TimeSpan FluxSyncTimeout => TimeSpan.FromSeconds( GetInt( "FluxSyncTimeout", 30 ) );

        /// <summary>
        /// Gets timeout for saving items.
        /// </summary>
        /// <value>
        /// The saving timeout.
        /// </value>
        public TimeSpan SavingTimeout => TimeSpan.FromSeconds( GetInt( "SavingTimeout", 60 ) );

        /// <summary>
        /// Gets the timeout for the material overlay appearance.
        /// </summary>
        /// <value>
        /// The material overlay appear timeout.
        /// </value>
        public TimeSpan MaterialOverlayAppearTimeout => TimeSpan.FromSeconds( GetInt( "MaterialOverlayAppearTimeout", 20 ) );

        /// <summary>
        /// Gets the timeout for the material overlay disappearance.
        /// </summary>
        /// <value>
        /// The material overlay disappear timeout.
        /// </value>
        public TimeSpan MaterialOverlayDisappearTimeout => TimeSpan.FromSeconds( GetInt( "MaterialOverlayDisappearTimeout", 60 ) );

        /// <summary>
        /// Gets the timeout for the machine overlay appearance.
        /// </summary>
        /// <value>
        /// The machine overlay appear timeout.
        /// </value>
        public TimeSpan MachineOverlayAppearTimeout => TimeSpan.FromSeconds( GetInt( "MachineOverlayAppearTimeout", 20 ) );

        /// <summary>
        /// Gets the timeout for the machine overlay disappearance.
        /// </summary>
        /// <value>
        /// The machine overlay disappear timeout.
        /// </value>
        public TimeSpan MachineOverlayDisappearTimeout => TimeSpan.FromSeconds( GetInt( "MachineOverlayDisappearTimeout", 60 ) );

        /// <summary>
        /// Gets the timeout for the part overlay appearance.
        /// </summary>
        /// <value>
        /// The part overlay appear timeout.
        /// </value>
        public TimeSpan PartOverlayAppearTimeout => TimeSpan.FromSeconds( GetInt( "PartOverlayAppearTimeout", 10 ) );

        /// <summary>
        /// Gets the timeout for the part overlay disappearance.
        /// </summary>
        /// <value>
        /// The part overlay disappear timeout.
        /// </value>
        public TimeSpan PartOverlayDisappearTimeout => TimeSpan.FromSeconds( GetInt( "PartOverlayDisappearTimeout", 90 ) );

        /// <summary>
        /// Gets the test results directory
        /// </summary>
        /// <value>
        /// The thest results directory
        /// </value>
        public string ResultsDirectory => mTestContext.ResultsDirectory;

        private string GetString( string key, string defaultValue )
        {
            var value = ( string )mTestContext.Properties[ key ];

            return string.IsNullOrEmpty( value ) ? defaultValue : value;
        }

        private int GetInt( string key, int defaultValue )
        {
            var value = ( string )mTestContext.Properties[ key ];

            return string.IsNullOrEmpty( value ) ? defaultValue : Convert.ToInt32( value );
        }

        private bool GetBool( string key, bool defaultValue )
        {
            var value = ( string )mTestContext.Properties[ key ];

            return string.IsNullOrEmpty( value ) ? defaultValue : Convert.ToBoolean( value );
        }
    }
}
