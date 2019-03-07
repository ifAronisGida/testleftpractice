using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

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
        /// Gets the test results directory
        /// </summary>
        /// <value>
        /// The thest results directory
        /// </value>
        public string ResultsDirectory => mTestContext.ResultsDirectory;

        public void Fill( object obj )
        {
            if( obj is null )
            {
                throw new ArgumentNullException( nameof( obj ) );
            }

            foreach( var property in obj.GetType().GetProperties( BindingFlags.Public | BindingFlags.Instance ) )
            {
                if( property.GetSetMethod( nonPublic: false ) is null || !mTestContext.Properties.Contains( property.Name ) )
                {
                    continue;
                }

                var value = ( string )mTestContext.Properties[property.Name];

                if( property.PropertyType == typeof( TimeSpan ) )
                {
                    property.SetValue( obj, TimeSpan.FromSeconds( int.Parse( value ) ) );
                }
                else
                {
                    throw new Exception( "Unsupported type." );
                }
            }
        }

        private bool HasKey( string key )
        {
            return mTestContext.Properties.Contains( key );
        }

        private string GetString( string key, string defaultValue )
        {
            var value = ( string )mTestContext.Properties[key];

            return string.IsNullOrEmpty( value ) ? defaultValue : value;
        }

        private int GetInt( string key, int defaultValue )
        {
            var value = ( string )mTestContext.Properties[key];

            return string.IsNullOrEmpty( value ) ? defaultValue : Convert.ToInt32( value );
        }

        private bool GetBool( string key, bool defaultValue )
        {
            var value = ( string )mTestContext.Properties[key];

            return string.IsNullOrEmpty( value ) ? defaultValue : Convert.ToBoolean( value );
        }
    }
}
