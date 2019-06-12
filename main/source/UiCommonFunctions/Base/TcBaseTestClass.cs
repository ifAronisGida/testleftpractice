using HomeZone.UiCommonFunctions.PageObjectHelpers;
using HomeZone.UiCommonFunctions.TestSettings;
using HomeZone.UiCommonFunctions.Utilities;
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

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
        private static bool mMachineDetailsReported;
        private AutoFact mAutoFact;
        private Process mTestedAppProcess;

        /// <summary>
        /// machine helper handling machine creation and deletion
        /// </summary>
        protected TcMachineHelper mMachineHelper = new TcMachineHelper();
        protected TcMaterialHelper mMaterialHelper = new TcMaterialHelper();
        protected TcPartHelper mPartHelper = new TcPartHelper();
        protected TcPartOrderHelper mPartOrderHelper = new TcPartOrderHelper();
        protected TcCutJobHelper mCutJobHelper = new TcCutJobHelper();
        protected TcNestingTemplateHelper mNestingTemplateHelper = new TcNestingTemplateHelper();
        protected TcCustomerHelper mCustomerHelper = new TcCustomerHelper();

        protected static IDriver Driver { get; } = new LocalDriver();

        [TestInitialize]
        public void Init()
        {
            TestSettings = new TcTestSettings( TestContext );
            TestSettings.Fill( TcPageObjectSettings.Instance );
            Log = new TcLogging( Driver, TestContext, TestSettings );

            ExecuteUITestPreparation( DoInitialization, "Test Initialization" );
        }

        /// <summary>
        /// Cleanup after test execution.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            DoTestCleanup();
        }

        /// <summary>
        /// The test context.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Property used for logging.
        /// </summary>
        public static TcLogging Log { get; private set; }

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
        /// Execute UI Test Preparation
        /// </summary>
        /// <param name="action">preparation function</param>
        /// <param name="caption">preparation description</param>
        protected void ExecuteUITestPreparation( Action action, [CallerMemberName] string caption = "" )
        {
            if( !mMachineDetailsReported )
            {
                mMachineDetailsReported = true;
                Log.Info( $"OS: {Environment.OSVersion.VersionString}, Memory: {GetTotalMemory()}" );
            }

            try
            {
                Log.OpenFolder( caption );
                action.Invoke();
                Log.CloseFolder();
            }
            catch( Exception ex )
            {
                Log.Error( ex.Message, ex.StackTrace ); //automatically creates a screenshot
                Log.CloseFolder();
                throw;
            }

            string GetTotalMemory()
            {
                var query = new ObjectQuery( "SELECT TotalPhysicalMemory FROM Win32_ComputerSystem" );
                var searcher = new ManagementObjectSearcher( query );
                var item = searcher.Get().Cast<ManagementObject>().First();

                return $"{( ulong ) item[ "TotalPhysicalMemory" ] / 1024 / 1024} MB";
            }
        }

        /// <summary>
        /// Execute a UI  Test.
        /// Function encapsulates the UI test with logging.
        /// A screenshot is taken to document the test start conditions.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="visual">The visual used for the screenshot. If null, HomeZone is used.</param>
        protected void ExecuteUITest( Action action, [CallerMemberName] string caption = "", IVisualObject visual = null )
        {
            try
            {
                Log.OpenFolder( caption, visual: visual ?? HomeZone.VisualObject );

                Act( action, caption );

                Log.Info( caption + " finished", visual: visual ?? HomeZone.VisualObject );
                Log.CloseFolder();
            }
            catch( Exception ex )
            {
                PostException( ex );
                Log.CloseFolder();
                throw;
            }

            void PostException( Exception ex, bool innerException = false )
            {
                Log.Error( $"{( innerException ? "Inner exception: " : "" )}{ex.Message}", ex.StackTrace ); //automatically creates a screenshot
                if( ex.InnerException != null )
                {
                    PostException( ex.InnerException, true );
                }
            }
        }

        protected void Act( Action action, [CallerMemberName] string caption = null )
            => mAutoFact.Act( action, caption );

        /// <summary>
        /// Save Log File after finishing all tests in Assembly
        /// </summary>
        protected static void AssemblyCleanup()
        {
            Log.Save();
        }

        /// <summary>
        /// Do test initialization
        /// </summary>
        protected virtual void DoInitialization()
        {
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
                    Log.Error( message );
                    throw new Exception( message );
                }

                var filename = Path.Combine( TestSettings.TestedAppPath, TestSettings.TestedAppName + ".exe" );
                var startInfo = new ProcessStartInfo
                {
                    FileName = filename,
                    WorkingDirectory = TestSettings.TestedAppPath
                };
                mTestedAppProcess = Process.Start( startInfo );
            }
            else
            {
                mTestedAppProcess = runningHomeZone[ 0 ];
            }

            // connect to HomeZone process and wait until visible
            HomeZone = new TcHomeZoneApp( TestSettings.TestedAppName, Driver );

            HomeZone.MainWindowExists.WaitFor( TimeSpan.FromSeconds( 90 ) );

            var info = GetHomeZoneInfo();
            if( info != null )
            {
                PostHomeZoneInfoToLog( info );
            }
            else
            {
                Log.Warning( "Could not extract HomeZone info." );
            }

            // close WelcomeScreen if visible
            var welcomeScreen = HomeZone.WelcomeScreen;
            if( welcomeScreen.IsVisible )
            {
                HomeZone.MainTabControl.CloseCurrentTab();
            }

            HomeZone.Maximize();

            // wait until machine templates are loaded
            Assert.IsTrue( HomeZone.BendMachineTemplatesLoaded() );

            if( TestSettings.ClearOldTestItemsAtStart )
            {
                Log.OpenFolder( "Delete existing test items" );
                mNestingTemplateHelper.DeleteTestNestingTemplates( TestSettings, HomeZone.NestingTemplates );
                mCutJobHelper.DeleteTestCutJobs( TestSettings, HomeZone.CutJobs );
                mPartOrderHelper.DeleteTestPartOrders( TestSettings, HomeZone.PartOrders );
                mPartHelper.DeleteTestParts( TestSettings, HomeZone.Parts );
                mCustomerHelper.DeleteTestCustomers( TestSettings, HomeZone.Customers );
                mMachineHelper.DeleteTestMachines( TestSettings, HomeZone.Machines );
                mMaterialHelper.DeleteTestMaterials( TestSettings, HomeZone.Materials, HomeZone.MainTabControl );
                Log.CloseFolder();
            }
        }

        /// <summary>
        /// Cleanup after testexecution
        /// </summary>
        protected virtual void DoTestCleanup()
        {
            if( TestContext.CurrentTestOutcome == UnitTestOutcome.Failed && TestSettings.KillTestedAppAfterFailedTest )
            {
                mTestedAppProcess?.Kill();
                //Wait after killing the HomeZone so that other processes like FluxAdapter, SpaceClaim, ... can terminate theirselve
                System.Threading.Thread.Sleep( 15000 );
            }
        }

        private string GetHomeZoneInfo()
        {
            var about = HomeZone.GotoMainMenu().OpenAboutDialog();

            try
            {
                about.CopyToClipboard();

                if( HomeZone.MessageBox.MessageBoxExists() )
                {
                    HomeZone.MessageBox.Ok();

                    return null;
                }

                return System.Windows.Forms.Clipboard.GetText();
            }
            finally
            {
                about.Close();
            }
        }

        // TestLeft throws an exception when the additional text is long enough.
        // This method posts the big homezone info text in chunks, clamping each string at 12000 chars.
        private void PostHomeZoneInfoToLog( string homezoneInfo )
        {
            var sb = new StringBuilder();
            var count = 1;

            foreach( var line in homezoneInfo.Split( '\n' ) )
            {
                if( sb.Length + line.Length < 12000 )
                {
                    sb.Append( line );
                }
                else
                {
                    Log.Info( $"HomeZone info pt. {count++}", sb.ToString() );
                    sb.Clear();
                }
            }

            if( sb.Length > 0 )
            {
                Log.Info( $"HomeZone info pt. {count}", sb.ToString() );
            }
        }
    }
}
