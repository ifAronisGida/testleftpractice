using System;
using System.Linq;
using System.Windows.Controls;
using PageObjectInterfaces.CutJob;
using SmartBear.TestLeft.TestObjects;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.Coparoo.Desktop.WPF;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcRawSheetList : TiRawSheetList
    {
        private readonly IControlObject mControlObject;

        public TcRawSheetList( IControlObject controlObject )
        {
            mControlObject = controlObject;
        }

        public int Count => mControlObject.Node.Cast<IObjectTreeNode>().Children.Count; // there's ChildCount, but it often doesn't work

        public TiRawSheet GetRawSheet( int index )
        {
            return new TcRawSheet( mControlObject.FindGeneric( Search.By<ContentPresenter>().AndByIndex( index ) ) );
        }
    }
}
