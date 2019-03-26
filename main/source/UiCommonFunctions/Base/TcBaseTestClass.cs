using HomeZone.UiObjectInterfaces;
using HomeZone.UiObjectInterfaces.Cut;
using HomeZone.UiObjectInterfaces.DatamanagerBend;
using HomeZone.UiObjectInterfaces.Design;
using HomeZone.UiObjectInterfaces.Flux;
using HomeZone.UiObjects;
using HomeZone.UiObjects.PageObjects.Cut;
using HomeZone.UiObjects.PageObjects.DatamanagerBend;
using HomeZone.UiObjects.PageObjects.Design;
using HomeZone.UiObjects.PageObjects.Flux;
using HomeZone.UiObjects.TestSettings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using System;
using System.Diagnostics;
using System.IO;
using Trumpf.AutoTest.Facts;

namespace HomeZone.UiCommonFunctions.Base
{
    /// <summary>
    /// Base class for all test classes.
    /// This class contains the connection to TestLeft via the Driver property,
    /// the TestContext, access to the HomeZone, Design, Cut and Flux process via properties and
    /// basic class and test initialization and clean up.
    /// </summary>
    [TestClass]
    public class TcBaseTestClass
    {
        private AutoFact mAutoFact;

        protected static IDriver Driver { get; } = new LocalDriver();

        [TestInitialize]
        public void Init()
        {
            TestSettings = new TcTestSettings( TestContext );
            TestSettings.Fill( TcPageObjectSettings.Instance );

            mAutoFact = new AutoFact( new TcTestOptions( GetType(), TestContext, TestSettings ) );

            DesignApp = new TcDesign( Driver );
            CutApp = new TcCut( Driver );
            FluxApp = new TcFlux( TestSettings.FluxProcessName, Driver );
            Flux = new TcFluxApp( TestSettings.FluxProcessName, Driver );
            DatamanagerBend = new TcDatamanagerBendApp( TestSettings.DatamanagerBendProcessName, Driver );

            TcAppLangDependentStrings.CurrentLanguage = TestSettings.ApplicationLanguage;

            // check if HomeZone is already running
            var runningHomeZone = Process.GetProcessesByName( TestSettings.TestedAppName );

            if( runningHomeZone.Length == 0 )               // not running => start HomeZone
            {
                if( !Directory.Exists( TestSettings.TestedAppPath ) )
                {
                    string message = "Path not found to start process! " + TestSettings.TestedAppPath;
                    Driver.Log.Error( message );
                    throw new Exception( message );
                }

                var filename = Path.Combine( TestSettings.TestedAppPath, TestSettings.TestedAppName + ".exe" );
                var startInfo = new ProcessStartInfo
                {
                    FileName = filename,
                    WorkingDirectory = TestSettings.TestedAppPath
                };
                var process = Process.Start( startInfo );
            }

            // connect to HomeZone process and wait until visible
            HomeZone = new TcHomeZoneApp( TestSettings.TestedAppName, Driver );

            HomeZone.MainWindowExists.WaitFor( TimeSpan.FromSeconds( 90 ) );

            // close WelcomeScreen if visible
            var welcomeScreen = HomeZone.WelcomeScreen;
            if( welcomeScreen.IsVisible )
            {
                HomeZone.MainTabControl.CloseCurrentTab();
            }

            HomeZone.Maximize();

            // wait until machine templates are loaded
            Assert.IsTrue( HomeZone.BendMachineTemplatesLoaded() );
        }

        /// <summary>
        /// The test context.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// The test settings.
        /// </summary>
        public static TcTestSettings TestSettings { get; private set; }

        /// <summary>
        /// Gets the HomeZone ProcessObject.
        /// </summary>
        /// <value>
        /// The HomeZone ProcessObject.
        /// </value>
        public static TiHomeZoneApp HomeZone { get; private set; }

        /// <summary>
        /// Manages access to the Design application.
        /// </summary>
        /// <value>
        /// The Design application.
        /// </value>
        public static TiDesign DesignApp { get; private set; }

        /// <summary>
        /// Manages access to the Cut application.
        /// </summary>
        /// <value>
        /// The Cut application.
        /// </value>
        public static TiCut CutApp { get; private set; }


        /// <summary>
        /// Manages access to the Flux application. TODO: Has to be refactored into TiFluxApp. Do not use this Class for new functionality
        /// </summary>
        /// <value>
        /// The Flux application.
        /// </value>
        public static TiFlux FluxApp { get; private set; }

        /// <summary>
        /// Manages access to the Flux application
        /// </summary>
        public static TiFluxApp Flux { get; private set; }

        /// <summary>
        /// Manages acces to the Datamanager Bend application
        /// </summary>
        public static TiDatamanagerBendApp DatamanagerBend { get; private set; }

        /// <summary>
        /// Execute a UI  Test
        /// Function encapsulates the UI test with logging
        /// </summary>
        /// <param name="action"></param>
        /// <param name="caption"></param>
        protected void ExecuteUITest( Action action, string caption )
        {
            try
            {
                Driver.Log.OpenFolder( caption );
                Act( action, caption );
                Driver.Log.CloseFolder();
            }
            catch( Exception ex )
            {
                Driver.Log.Error( ex.Message, ex.StackTrace ); //automatically creates a screenshot
                Driver.Log.CloseFolder();
                throw;
            }
        }

        protected void Act( Action action, string caption = null )
            => mAutoFact.Act( action, caption );

        /// <summary>
        /// Save Log File after finishing all tests in Assembly
        /// </summary>
        protected static void AssemblyCleanup()
        {
            Driver.Log.Save( TestSettings.HtmlReportPath ?? TestSettings.ResultsDirectory, Log.Format.Html );
        }
    }
}
