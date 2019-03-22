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
        private readonly Lazy<TcDeductionValues> mDeductionValues;

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

        public Wool MainWindowExists => mMainWindow.Value.Exists;

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
        #endregion
    }
}
