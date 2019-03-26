#region HEADER
//--------------------------------------------------------------------------------------------------
// All rights reserved to TRUMPF GmbH + Co. KG, Germany
// -------------------------------------------------------------------------------------------------
//
//$File: $
//$Author: $
//$Revision: $ - $Date: $ 
// -------------------------------------------------------------------------------------------------
#endregion

#region USING

using HomeZone.UiObjectInterfaces.DatamanagerBend;
using SmartBear.TestLeft;
using System;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.Waiting;

#endregion

namespace HomeZone.UiObjects.PageObjects.DatamanagerBend
{
    public class TcDatamanagerBendApp : ProcessObject, TiDatamanagerBendApp
    {
        #region private constants

        private readonly Lazy<TcMainWindowDatamanagerBend> mMainWindow;

        #endregion

        #region constructor

        public TcDatamanagerBendApp( string processname, IDriver driver ) : base( processname )
        {
            Driver = driver;
            mMainWindow = new Lazy<TcMainWindowDatamanagerBend>( On<TcMainWindowDatamanagerBend> );
        }



        #endregion

        #region public static methods
        #endregion

        #region public methods

        /// <summary>
        /// Close the Datamanager
        /// </summary>
        public void Close()
        {
            mMainWindow.Value.Close();
        }

        #endregion

        #region private methods

        #endregion

        #region public static members
        #endregion

        #region private static members
        #endregion

        #region private members
        #endregion

        #region properties

        /// <summary>
        /// Check if the datamanager main window exists
        /// </summary>
        public Wool MainWindowExists => mMainWindow.Value.Exists;



        /// <summary>
        /// Deduction value Tab
        /// </summary>
        public TiDeductionValues DeductionValues => On<TcDeductionValues>();

        #endregion
    }
}
