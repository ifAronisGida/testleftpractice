using HomeZone.UiObjects.TestSettings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;

namespace HomeZone.UiCommonFunctions.Utilities
{
    /// <summary>
    /// Logging class.
    /// </summary>
    public class TcLogging
    {
        private IDriver mDriver;
        private TestContext mTestContext;
        private TcTestSettings mTestSettings;

        /// <summary>Initializes a new instance of the <see cref="TcLogging"/> class.</summary>
        /// <param name="driver">The driver.</param>
        /// <param name="testContext">The test context.</param>
        /// <param name="testSettings">The test settings.</param>
        public TcLogging( IDriver driver, TestContext testContext, TcTestSettings testSettings )
        {
            mDriver = driver;
            mTestContext = testContext;
            mTestSettings = testSettings;
        }

        /// <summary>Logs the specified information.</summary>
        /// <param name="info">The information.</param>
        /// <param name="additionalInfo">The additional information.</param>
        public void Info( string info, string additionalInfo = "" )
        {
            mDriver.Log.Message( info, additionalInfo );
        }

        /// <summary>
        /// Logs the specified warning.
        /// </summary>
        /// <param name="warning">The warning.</param>
        /// <param name="additionalInfo">The additional information.</param>
        public void Warning( string warning, string additionalInfo = "" )
        {
            mDriver.Log.Warning( warning, additionalInfo );
        }

        /// <summary>
        /// Logs the specified error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="additionalInfo">The additional information.</param>
        public void Error( string error, string additionalInfo = "" )
        {
            mDriver.Log.Error( error, additionalInfo );
        }

        /// <summary>
        /// Logs the specified picture.
        /// </summary>
        /// <param name="picture">The picture.</param>
        /// <param name="text">The optional text.</param>
        /// <param name="additionalInfo">The optional additional information.</param>
        public void Picture( System.Drawing.Image picture, string text = "", string additionalInfo = "" )
        {
            mDriver.Log.Picture( picture, text, additionalInfo );
        }

        /// <summary>
        /// Logs a screenshot of the specified object.
        /// </summary>
        /// <param name="objectForPicture">The object from which a screenshot is logged.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="additionalInfo">The additional information.</param>
        public void Screenshot( IVisualObject objectForPicture, string caption = "", string additionalInfo = "" )
        {
            mDriver.Log.Screenshot( objectForPicture, caption, additionalInfo );
        }

        /// <summary>
        /// Opens a folder in the log.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="additionalInfo">The additional information.</param>
        public void OpenFolder( string caption, string additionalInfo = "" )
        {
            mDriver.Log.OpenFolder( caption, additionalInfo );
        }

        /// <summary>
        /// Closes the folder in the log.
        /// </summary>
        public void CloseFolder()
        {
            mDriver.Log.CloseFolder();
        }

        /// <summary>
        /// Saves the log.
        /// </summary>
        public void Save()
        {
            mDriver.Log.Save( mTestSettings.HtmlReportPath ?? mTestSettings.ResultsDirectory, Log.Format.Html );
        }
    }
}
