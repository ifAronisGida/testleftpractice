using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeft.TestLeftBase.Settings
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

        public string Product => ( string )mTestContext.Properties[ "Product" ];

        public string Version => ( string )mTestContext.Properties[ "Version" ];

        public string Context
        {
            get
            {
                var context = ( string )mTestContext.Properties[ "Context" ];
                return string.IsNullOrEmpty( context ) ? Environment.MachineName : context;
            }
        }

        public string Process => ( string )mTestContext.Properties[ "Process" ];

        public string Remarks => ( string )mTestContext.Properties[ "Remarks" ];

        public bool FactsHubEnabled => Convert.ToBoolean( mTestContext.Properties[ "FactsHubEnabled" ] );
        public string FactsHubAddress => ( string )mTestContext.Properties[ "FactsHubAddress" ];

        public bool ScreenRecorderEnabled => Convert.ToBoolean( mTestContext.Properties[ "ScreenRecorderEnabled" ] );

        public string TestedAppName => ( string )mTestContext.Properties[ "TestedAppName" ];
        public string TestedAppPath => ( string )mTestContext.Properties[ "TestedAppPath" ];

        /// <summary>
        /// Gets the name prefix. This can be used to identify test items for example.
        /// </summary>
        /// <value>
        /// The name prefix.
        /// </value>
        public string NamePrefix => ( string )mTestContext.Properties[ "NamePrefix" ];

        /// <summary>
        /// Gets the name of the Flux process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public string FluxProcessName => ( string )mTestContext.Properties[ "FluxProcessName" ];

        /// <summary>
        /// Gets timeout for starting Design.
        /// </summary>
        /// <value>
        /// The Design starting timeout.
        /// </value>
        public TimeSpan DesignStartTimeout => TimeSpan.FromSeconds( Convert.ToInt32( mTestContext.Properties[ "DesignStartTimeout" ] ) );

        /// <summary>
        /// Gets timeout for starting Cut.
        /// </summary>
        /// <value>
        /// The Cut starting timeout.
        /// </value>
        public TimeSpan CutStartTimeout => TimeSpan.FromSeconds( Convert.ToInt32( mTestContext.Properties[ "CutStartTimeout" ] ) );

        /// <summary>
        /// Gets timeout for starting Flux.
        /// </summary>
        /// <value>
        /// The Flux starting timeout.
        /// </value>
        public TimeSpan FluxStartTimeout => TimeSpan.FromSeconds( Convert.ToInt32( mTestContext.Properties[ "FluxStartTimeout" ] ) );

        /// <summary>
        /// Gets timeout for saving items.
        /// </summary>
        /// <value>
        /// The saving timeout.
        /// </value>
        public TimeSpan SavingTimeout => TimeSpan.FromSeconds( Convert.ToInt32( mTestContext.Properties[ "SavingTimeout" ] ) );

        /// <summary>
        /// Gets the timeout for the material overlay appearance.
        /// </summary>
        /// <value>
        /// The material overlay appear timeout.
        /// </value>
        public TimeSpan MaterialOverlayAppearTimeout => TimeSpan.FromSeconds( Convert.ToInt32( mTestContext.Properties[ "MaterialOverlayAppearTimeout" ] ) );

        /// <summary>
        /// Gets the timeout for the material overlay disappearance.
        /// </summary>
        /// <value>
        /// The material overlay disappear timeout.
        /// </value>
        public TimeSpan MaterialOverlayDisappearTimeout => TimeSpan.FromSeconds( Convert.ToInt32( mTestContext.Properties[ "MaterialOverlayDisappearTimeout" ] ) );

        /// <summary>
        /// Gets the timeout for the machine overlay appearance.
        /// </summary>
        /// <value>
        /// The machine overlay appear timeout.
        /// </value>
        public TimeSpan MachineOverlayAppearTimeout => TimeSpan.FromSeconds( Convert.ToInt32( mTestContext.Properties[ "MachineOverlayAppearTimeout" ] ) );

        /// <summary>
        /// Gets the timeout for the machine overlay disappearance.
        /// </summary>
        /// <value>
        /// The machine overlay disappear timeout.
        /// </value>
        public TimeSpan MachineOverlayDisappearTimeout => TimeSpan.FromSeconds( Convert.ToInt32( mTestContext.Properties[ "MachineOverlayDisappearTimeout" ] ) );

        /// <summary>
        /// Gets the timeout for the part overlay appearance.
        /// </summary>
        /// <value>
        /// The part overlay appear timeout.
        /// </value>
        public TimeSpan PartOverlayAppearTimeout => TimeSpan.FromSeconds( Convert.ToInt32( mTestContext.Properties[ "PartOverlayAppearTimeout" ] ) );

        /// <summary>
        /// Gets the timeout for the part overlay disappearance.
        /// </summary>
        /// <value>
        /// The part overlay disappear timeout.
        /// </value>
        public TimeSpan PartOverlayDisappearTimeout => TimeSpan.FromSeconds( Convert.ToInt32( mTestContext.Properties[ "PartOverlayDisappearTimeout" ] ) );
    }
}
